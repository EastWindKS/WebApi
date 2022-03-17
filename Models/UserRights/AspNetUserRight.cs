using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.UserRights;

[Table("AspNetUserRights")]
public class AspNetUserRight
{
    public Guid Id { get; set; }

    public string AspNetUserId { get; set; }

    public int OfficeId { get; set; }

    public int ActionId { get; set; }

    [ForeignKey("ActionId")]
    public RightControllerAction RightControllerAction { get; set; }
}