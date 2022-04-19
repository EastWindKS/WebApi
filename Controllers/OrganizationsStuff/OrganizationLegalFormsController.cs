using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.Interfaces.Organizations;
using WebAPI.Dtos.Organizations;

namespace WebAPI.Controllers.OrganizationsStuff;

[Route("api/[controller]")]
[ApiController]
public class OrganizationLegalFormsController : ControllerBase
{
    private readonly IMapper _mapper;

    private readonly IOrganizationLegalFormRepository _organizationLegalFormRepository;

    public OrganizationLegalFormsController(IOrganizationLegalFormRepository organizationLegalFormRepository, IMapper mapper)
    {
        _organizationLegalFormRepository = organizationLegalFormRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("GetAll")]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var organizationLegalForms = await _organizationLegalFormRepository.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<OrganizationLegalFormDto>>(organizationLegalForms));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("GetByCountryId")]
    [Authorize]
    public IActionResult GetByCountryId(int countryId)
    {
        try
        {
            var organizationLegalForms = _organizationLegalFormRepository.GetByCountryId(countryId);

            return Ok(_mapper.Map<IEnumerable<OrganizationLegalFormDto>>(organizationLegalForms));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}