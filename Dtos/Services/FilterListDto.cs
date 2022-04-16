using SearchOption = WebAPI.Models.Filters.SearchOption;

namespace WebAPI.Dtos.Services;

public class FilterListDto
{
    public int Id { get; set; }

    public byte? Tail { get; set; }

    public int? PropertyDataTypeId { get; set; }

    public string PropertyDataType { get; set; }

    public string PropertyName { get; set; }

    public string PropertyDisplayName { get; set; }

    public int? DefaultSearchOptionId { get; set; }

    public string DefaultSearchOptionName { get; set; }

    public string DefaultValue { get; set; }

    public string DefaultValueText { get; set; }

    public bool FilterSet { get; set; }

    public bool Required { get; set; }

    public string ControllerName { get; set; }

    public string Method { get; set; }

    public bool NeedsOfficeIds { get; set; }

    public bool OnlyExtendedSearch { get; set; }

    public List<SearchOption> SearchOptions { get; set; } = new List<SearchOption>();
}