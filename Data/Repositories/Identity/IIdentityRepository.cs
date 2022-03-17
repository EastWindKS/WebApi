using Microsoft.AspNetCore.Identity;
using WebAPI.Models.Authenticate;
using WebAPI.Services.Novell;

namespace WebAPI.Data.Repositories.Identity
{
    public interface IIdentityRepository
    {
        Task CreateNewUser(NovellUser novellUser, UserManager<ApplicationUser> userManager);
    }
}