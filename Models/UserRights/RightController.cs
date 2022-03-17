using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.UserRights;

[Table("RightController")]
public class RightController
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int BoxId { get; set; }
}