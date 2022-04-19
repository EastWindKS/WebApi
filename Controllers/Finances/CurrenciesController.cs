using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.Interfaces.Finances;
using WebAPI.Dtos.Finances;

namespace WebAPI.Controllers.Finances;

[Route("api/[controller]")]
[ApiController]
public class CurrenciesController : ControllerBase
{
    private readonly IMapper _mapper;

    private readonly ICurrencyRepository _currencyRepository;

    public CurrenciesController(IMapper mapper, ICurrencyRepository currencyRepository)
    {
        _mapper = mapper;
        _currencyRepository = currencyRepository;
    }

    [HttpGet]
    [Route("GetAll")]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var currencies = await _currencyRepository.GetAllAsync();
            
            return Ok(_mapper.Map<IEnumerable<CurrencyDto>>(currencies));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}