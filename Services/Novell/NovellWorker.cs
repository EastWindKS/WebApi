using System.DirectoryServices.Protocols;
using System.Net;
using WebAPI.Models.Authenticate;

namespace WebAPI.Services.Novell
{
    public class NovellWorker : INovellWorker
    {
        private readonly IConfiguration _configuration;

        private LdapConnection _ldapConnection = null!;

        public NovellWorker(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public NovellUser AuthenticateInNovell(LoginModel loginModel)
        {
            using (_ldapConnection = CreateConnect())
            {
                BindConnection();
                var novellUser = Search(loginModel.UserName);
                var isVerified = VerifyPassword(novellUser.DN, loginModel.Password);

                if (isVerified)
                {
                    novellUser.Password = loginModel.Password;
                    return novellUser;
                }

                throw new Exception("Incorrect password.");
            }
        }

        private LdapConnection CreateConnect()
        {
            var novellConnection = _configuration.GetSection("NovellConnection").Get<NovellConnection>();
            var ldapConnection = new LdapConnection(new LdapDirectoryIdentifier(novellConnection.Address, novellConnection.Port));
            ldapConnection.SessionOptions.VerifyServerCertificate = (_, _) => true;
            ldapConnection.SessionOptions.ProtocolVersion = 3;
            ldapConnection.AuthType = AuthType.Basic;

            return ldapConnection;
        }

        private bool VerifyPassword(string userDN, string password)
        {
            try
            {
                _ldapConnection.Bind(new NetworkCredential(userDN, password));

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void BindConnection()
        {
            _ldapConnection.Bind(new NetworkCredential(_configuration["Novell:Login"], _configuration["Novell:Password"]));
        }

        private NovellUser Search(string login)
        {
            var novellUser = new NovellUser
            {
                Attributes = new Dictionary<string, string[]>()
            };

            var searchRequest = ConstructSearchRequest("world", login);
            var searchResponse = (SearchResponse) _ldapConnection.SendRequest(searchRequest);

            if (searchResponse.Entries.Count == 0)
            {
                searchRequest = ConstructSearchRequest("alien", login);
                searchResponse = (SearchResponse) _ldapConnection.SendRequest(searchRequest);
            }

            if (searchResponse.Entries.Count < 1)
            {
                throw new Exception("User not find.");
            }

            novellUser.DN = searchResponse.Entries[0]?.DistinguishedName;

            foreach (byte[] item in searchResponse.Entries[0].Attributes["cn"])
            {
                novellUser.CN = System.Text.Encoding.Default.GetString(item);
            }

            foreach (string attrName in searchResponse.Entries[0].Attributes.AttributeNames)
            {
                var attrs = new List<string>();

                foreach (byte[] item in searchResponse.Entries[0].Attributes[attrName])
                {
                    attrs.Add(System.Text.Encoding.Default.GetString(item));
                }

                novellUser.Attributes.Add(attrName, attrs.ToArray());
            }

            return novellUser;
        }

        private static SearchRequest ConstructSearchRequest(string param, string login)
        {
            return new SearchRequest(
                $"o={param}",
                "cn=" + login,
                SearchScope.Subtree,
                "*");
        }
    }
}