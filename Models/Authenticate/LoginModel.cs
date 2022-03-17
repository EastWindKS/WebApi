using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Authenticate
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}