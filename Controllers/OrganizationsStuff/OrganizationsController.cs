using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.Interfaces.Organizations;
using WebAPI.Data.Repositories.Organizations;
using WebAPI.Dtos.Organizations;
using WebAPI.Models.Organizations;

namespace WebAPI.Controllers.OrganizationsStuff;

[Route("api/[controller]")]
[ApiController]
public class OrganizationsController : ControllerBase
{
    private readonly IOrganizationRepository _organizationsRepository;

    private readonly IMapper _mapper;

    public OrganizationsController(IOrganizationRepository organizationsRepository, IMapper mapper)
    {
        _organizationsRepository = organizationsRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("GetById")]
    [Authorize]
    public async Task<IActionResult> GetById([FromQuery] int organizationId)
    {
        try
        {
            var organization = await _organizationsRepository.GetAsync(organizationId);

            return Ok(_mapper.Map<OrganizationDto>(organization));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("GetAll")]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var organizations = await _organizationsRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<OrganizationListView>>(organizations));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Route("Post")]
    [Authorize]
    public async Task<IActionResult> InsertOrganization(OrganizationDto organizationDto)
    {
        try
        {
            var insertedOrganizationId = await _organizationsRepository.InsertAsync(_mapper.Map<Organization>(organizationDto));
            var insertedOrganization = await _organizationsRepository.GetAsync(insertedOrganizationId);
            return Ok(_mapper.Map<OrganizationDto>(insertedOrganization));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [Route("Put")]
    [Authorize]
    public async Task<IActionResult> UpdateOrganization(OrganizationDto organizationDto)
    {
        try
        {
            var insertedOrganizationId = await _organizationsRepository.UpdateAsync(_mapper.Map<Organization>(organizationDto));
            var insertedOrganization = await _organizationsRepository.GetAsync(insertedOrganizationId);
            return Ok(_mapper.Map<OrganizationDto>(insertedOrganization));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    [Route("Delete")]
    [Authorize]
    public async Task<IActionResult> Delete(int organizationId)
    {
        try
        {
            await _organizationsRepository.DeleteAsync(organizationId);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}