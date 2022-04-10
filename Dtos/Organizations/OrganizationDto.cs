using WebAPI.Dtos.Addresses;

namespace WebAPI.Dtos.Organizations;

public class OrganizationDto
{
    public int Id { get; set; }

    public string NativeName { get; set; } = null!;

    public string ShortName { get; set; }

    public string Skype { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public string Website { get; set; }

    public int? CountryId { get; set; }

    public string Managers { get; set; }

    public string Offices { get; set; }

    public int? OrganizationLegalFormId { get; set; }

    public int? ParentOrganizationId { get; set; }

    public OrganizationLegalFormDto OrganizationLegalForm { get; set; }

    public CountryDto Country { get; set; }
}