using WebAPI.Data.Interfaces.Systems;
using WebAPI.Models.Organizations;

namespace WebAPI.Data.Interfaces.Organizations;

public interface IOrganizationLegalFormRepository : IModelRepository<OrganizationLegalForm>
{
    public IEnumerable<OrganizationLegalForm> GetByCountryId(int countryId);
}