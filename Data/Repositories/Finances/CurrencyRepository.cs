using WebAPI.Data.Context;
using WebAPI.Data.Interfaces.Finances;
using WebAPI.Data.Repositories.Services;
using WebAPI.Models.Finances;

namespace WebAPI.Data.Repositories.Finances;

public class CurrencyRepository : ModelRepository<Currency>, ICurrencyRepository
{
    public CurrencyRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory, Property)
    {
    }

    private static string Property => string.Empty;
}