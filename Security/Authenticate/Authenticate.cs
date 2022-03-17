using Microsoft.AspNetCore.Identity;
using WebAPI.Data.Repositories.Identity;
using WebAPI.Models.Authenticate;
using WebAPI.Services.JWT;
using WebAPI.Services.Novell;

namespace WebAPI.Security.Authenticate
{
    public class Authenticate : IAuthenticate
    {
        public Authenticate(UserManager<ApplicationUser> userManager, IJwtWorker jwtWorker, INovellWorker novellWorker, IIdentityRepository identityRepository)
        {
            _userManager = userManager;
            _jwtWorker = jwtWorker;
            _identityRepository = identityRepository;
            _novellWorker = novellWorker;
        }

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IJwtWorker _jwtWorker;

        private readonly INovellWorker _novellWorker;

        private readonly IIdentityRepository _identityRepository;

        public async Task<JwtTokenModel> GetAuthentication(LoginModel loginModel)
        {
            var applicationUser = await ConfirmAuthorization(loginModel);

            if (applicationUser is not null)
            {
                return _jwtWorker.GetToken(applicationUser);
            }

            var novellUser = _novellWorker.AuthenticateInNovell(loginModel);
            await _identityRepository.CreateNewUser(novellUser, _userManager);
            applicationUser = await ConfirmAuthorization(loginModel);

            return _jwtWorker.GetToken(applicationUser);
        }

        private async Task<ApplicationUser> ConfirmAuthorization(LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                return user;
            }

            return null;
        }
    }
}