using WebAPI.Data.Context;
using WebAPI.Data.Interfaces.Organizations;
using WebAPI.Models.Organizations;

namespace WebAPI.Data.Repositories.Organizations;

public class OrganizationRepository : ModelRepository<Organization>, IOrganizationRepository
{
    public OrganizationRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory, Property)
    {
    }

    private static string Property => @"
        Country, 
        OrganizationLegalForm, 
        ChildOrganizations";
}