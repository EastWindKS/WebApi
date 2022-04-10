using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Models.Authenticate;

namespace WebAPI.Services.JWT
{
    public sealed class JwtWorker : IJwtWorker
    {
        public JwtWorker(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;

        public JwtTokenModel GetToken(ApplicationUser applicationUser)
        {
            var claims = CreateClaims(applicationUser);
            var jwtSecurityToken = CreateToken(claims);

            return FormattingJwtToken(jwtSecurityToken, applicationUser.UserName);
        }

        private JwtSecurityToken CreateToken(IEnumerable<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                _configuration["JWT:ValidIssuer"],
                _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }

        private static JwtTokenModel FormattingJwtToken(JwtSecurityToken jwtSecurityToken, string userName)
        {
            return new JwtTokenModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Valid = ((DateTimeOffset) jwtSecurityToken.ValidTo).ToUnixTimeSeconds().ToString(),
                UserName = userName
            };
        }

        private static IEnumerable<Claim> CreateClaims(ApplicationUser applicationUser)
        {
            return new List<Claim>
            {
                new(ClaimTypes.Name, applicationUser.UserName),
                new(ClaimTypes.NameIdentifier, applicationUser.Id),
                new("Office", applicationUser.OfficeId.ToString())
            };
        }
    }
}