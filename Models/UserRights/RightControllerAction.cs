using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.UserRights;

[Table("RightControllerAction")]
public class RightControllerAction
{
    public int Id { get; set; }

    public int ControllerId { get; set; }

    public string Name { get; set; }

    [ForeignKey("ControllerId")]
    public RightController RightController { get; set; }
}