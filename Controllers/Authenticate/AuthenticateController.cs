using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Authenticate;
using WebAPI.Security.Authenticate;
using WebAPI.Security.AuthorizeRights;

namespace WebAPI.Controllers.Authenticate
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        public AuthenticateController(IAuthenticate authenticate)
        {
            _authenticate = authenticate;
        }

        private readonly IAuthenticate _authenticate;

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(model);
                }

                var token = await _authenticate.GetAuthentication(model);

                return Ok(token);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("Test")]
        [RightsFilter]
        [Authorize]
        public IActionResult Test()
        {
            const string hello = "HELLO";

            return Ok(hello);
        }
    }
}