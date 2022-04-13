using WebAPI.Data.Interfaces.Systems;

namespace WebAPI.Models.Organizations;

public class Office : IContainId
{
    public int Id { get; set; }

    public string ShortName { get; set; }
}