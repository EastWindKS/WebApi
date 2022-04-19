using WebAPI.Data.Context;
using WebAPI.Data.Interfaces.Organizations;
using WebAPI.Data.Repositories.Services;
using WebAPI.Models.Organizations;

namespace WebAPI.Data.Repositories.Organizations;

public class OrganizationLegalFormRepository : ModelRepository<OrganizationLegalForm>, IOrganizationLegalFormRepository
{
    public OrganizationLegalFormRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory, Property)
    {
    }

    private static string Property => string.Empty;

    public IEnumerable<OrganizationLegalForm> GetByCountryId(int countryId)
    {
        return GetAsync(f => f.CountryId == countryId);
    }
}