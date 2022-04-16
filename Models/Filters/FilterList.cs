using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Data.Interfaces.Systems;
using WebAPI.Models.UserRights;

namespace WebAPI.Models.Filters;

[Table("FilterList")]
public class FilterList : IContainId
{
    public int Id { get; set; }

    public int? RightControllerId { get; set; }

    public byte? Tail { get; set; }

    public int? PropertyDataTypeId { get; set; }

    public string PropertyName { get; set; }

    public string PropertyDisplayName { get; set; }

    public int? DefaultSearchOptionId { get; set; }

    public string DefaultValue { get; set; }

    public string DefaultValueText { get; set; }

    public bool Required { get; set; }

    public string ControllerName { get; set; }

    public string Method { get; set; }

    public bool NeedsOfficeIds { get; set; }

    public bool OnlyExtendedSearch { get; set; }

    [ForeignKey("PropertyDataTypeId")]
    public PropertyDataType PropertyDataType { get; set; }

    [ForeignKey("RightControllerId")]
    public RightController RightController { get; set; }
}