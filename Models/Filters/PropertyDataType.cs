using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Data.Interfaces.Systems;

namespace WebAPI.Models.Filters;

[Table("PropertyDataType")]
public class PropertyDataType : IContainId
{
    public int Id { get; set; }

    public string TypeName { get; set; }

    public List<SearchOptionPropertyDataTypeLink> SearchOptionPropertyDataTypeLink { get; set; } = new();
}