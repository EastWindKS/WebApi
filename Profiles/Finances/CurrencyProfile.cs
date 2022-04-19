using AutoMapper;
using WebAPI.Dtos.Finances;
using WebAPI.Models.Finances;

namespace WebAPI.Profiles.Finances;

public class CurrencyProfile : Profile
{
    public CurrencyProfile()
    {
        CreateMap<Currency, CurrencyDto>();
    }
}