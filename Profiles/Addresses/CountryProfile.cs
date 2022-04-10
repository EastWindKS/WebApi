using AutoMapper;
using WebAPI.Dtos.Addresses;
using WebAPI.Models.Addresses;

namespace WebAPI.Profiles.Addresses;

public class CountryProfile : Profile
{
    public CountryProfile()
    {
        CreateMap<Country, CountryDto>();
        CreateMap<CountryDto, Country>();
    }
}