using WebAPI.Models.Authenticate;

namespace WebAPI.Services.JWT
{
    public interface IJwtWorker
    {
        public JwtTokenModel GetToken(ApplicationUser applicationUser);
    }
}