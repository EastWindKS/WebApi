using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Data.Interfaces.Systems;

namespace WebAPI.Models.Filters;

[Table("SearchOptionPropertyDataTypeLink")]
public class SearchOptionPropertyDataTypeLink : IContainId
{
    public int Id { get; set; }

    public int? SearchOptionId { get; set; }

    public int? PropertyDataTypeId { get; set; }

    [ForeignKey("SearchOptionId")]
    public SearchOption SearchOption { get; set; }
}