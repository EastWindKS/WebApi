using AutoMapper;
using WebAPI.Dtos.Organizations;
using WebAPI.Models.Organizations;

namespace WebAPI.Profiles.Organizations;

public class OrganizationProfile : Profile
{
    public OrganizationProfile()
    {
        CreateMap<Organization, OrganizationDto>();
        CreateMap<OrganizationDto, Organization>();
    }
}