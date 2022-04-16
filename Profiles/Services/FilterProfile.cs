using AutoMapper;
using WebAPI.Dtos.Services;
using WebAPI.Models.Filters;

namespace WebAPI.Profiles.Services;

public class FilterProfile : Profile
{
    public FilterProfile()
    {
        CreateMap<FilterList, FilterListDto>()
            .ForMember(f => f.PropertyDataType, opt =>
                opt.MapFrom(f => f.PropertyDataType.TypeName))
            .ForMember(f => f.FilterSet, opt =>
                opt.MapFrom(f => f.DefaultValue != null))
            .ForMember(f => f.SearchOptions, opt =>
                opt.MapFrom(f => f.PropertyDataType.SearchOptionPropertyDataTypeLink.Select(s => s.SearchOption).ToList()))
            .ForMember(f => f.DefaultSearchOptionName, opt =>
                opt.MapFrom(f => f.PropertyDataType.SearchOptionPropertyDataTypeLink.Select(s => s.SearchOption).FirstOrDefault().Title));
    }
}