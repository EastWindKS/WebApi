using WebAPI.Models.Authenticate;

namespace WebAPI.Services.Novell
{
    public interface INovellWorker
    {
        public NovellUser AuthenticateInNovell(LoginModel loginModel);
    }
}