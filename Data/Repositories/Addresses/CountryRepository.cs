using WebAPI.Data.Context;
using WebAPI.Data.Interfaces.Addresses;
using WebAPI.Data.Repositories.Services;
using WebAPI.Models.Addresses;

namespace WebAPI.Data.Repositories.Addresses;

public class CountryRepository : ModelRepository<Country>, ICountryRepository
{
    public CountryRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory, Property)
    {
    }

    private static string Property => string.Empty;
}