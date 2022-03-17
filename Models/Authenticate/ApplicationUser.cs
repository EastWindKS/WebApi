using Microsoft.AspNetCore.Identity;

namespace WebAPI.Models.Authenticate;

public class ApplicationUser : IdentityUser
{
    public string TableName { get; set; }
    
    public int TableId { get; set; }
    
    public int OfficeId { get; set; }
}