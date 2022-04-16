using WebAPI.Data.Context;
using WebAPI.Data.Interfaces.Services;
using WebAPI.Models.Filters;

namespace WebAPI.Data.Repositories.Services;

public class FilterListRepository : ModelRepository<FilterList>, IFilterListRepository
{
    public FilterListRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory, Property)
    {
    }

    private static string Property => "PropertyDataType.SearchOptionPropertyDataTypeLink.SearchOption";

    public IEnumerable<FilterList> GetByControllerName(string name)
    {
        return GetAsync(f => f.RightController.Name == name);
    }
}