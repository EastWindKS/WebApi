using AutoMapper;
using WebAPI.Dtos.Organizations;
using WebAPI.Models.Organizations;

namespace WebAPI.Profiles.Organizations;

public class OrganizationLegalFormProfile : Profile
{
    public OrganizationLegalFormProfile()
    {
        CreateMap<OrganizationLegalForm, OrganizationLegalFormDto>();
        CreateMap<OrganizationLegalFormDto, OrganizationLegalForm>();
    }
}