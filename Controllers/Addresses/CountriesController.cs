using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.Interfaces.Addresses;
using WebAPI.Dtos.Addresses;

namespace WebAPI.Controllers.Addresses;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly ICountryRepository _countryRepository;

    private readonly IMapper _mapper;

    public CountriesController(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("GetAll")]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var countries = await _countryRepository.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<CountryDto>>(countries));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}