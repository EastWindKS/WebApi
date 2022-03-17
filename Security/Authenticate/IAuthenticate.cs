using WebAPI.Models.Authenticate;
using WebAPI.Services.JWT;

namespace WebAPI.Security.Authenticate
{
    public interface IAuthenticate
    {
        public Task<JwtTokenModel> GetAuthentication(LoginModel loginModel);
    }
}