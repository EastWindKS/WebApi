using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.Interfaces.Services;
using WebAPI.Dtos.Services;

namespace WebAPI.Controllers.Services;

[Route("api/[controller]")]
[ApiController]
public class FiltersLists : ControllerBase
{
    private readonly IMapper _mapper;

    private readonly IFilterListRepository _filterListRepository;

    public FiltersLists(IMapper mapper, IFilterListRepository filterListRepository)
    {
        _mapper = mapper;
        _filterListRepository = filterListRepository;
    }

    [HttpGet]
    [Route("GetByControllerName")]
    [Authorize]
    public IActionResult GetByControllerName(string controllerName)
    {
        try
        {
            var filterLists = _filterListRepository.GetByControllerName(controllerName);

            return Ok(_mapper.Map<IEnumerable<FilterListDto>>(filterLists));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}