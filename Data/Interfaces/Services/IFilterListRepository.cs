using WebAPI.Data.Interfaces.Systems;
using WebAPI.Models.Filters;

namespace WebAPI.Data.Interfaces.Services;

public interface IFilterListRepository : IModelRepository<FilterList>
{
    IEnumerable<FilterList> GetByControllerName(string name);
}