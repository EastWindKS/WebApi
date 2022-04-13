using AutoMapper;
using WebAPI.Dtos.Organizations;
using WebAPI.Models.Organizations;

namespace WebAPI.Profiles.Organizations;

public class OrganizationProfile : Profile
{
    public OrganizationProfile()
    {
        CreateMap<Organization, OrganizationDto>();
        CreateMap<Organization, OrganizationListView>()
            .ForMember(orgView => orgView.Country, opt => opt.MapFrom(org => org.Country.InternationalName))
            .ForMember(orgView => orgView.Managers, opt => opt.MapFrom(org => string.Join(", ", org.OrganizationOwners.Select(s => s.Employee.GetShortName()))))
            .ForMember(orgView => orgView.Offices, opt => opt.MapFrom(org=>string.Join(", ", org.OrganizationOwners.SelectMany(s => s.Employee.OrganizationEmployee).Select(s => s.Organization.ShortName).Distinct())));

        CreateMap<OrganizationDto, Organization>();
    }
}