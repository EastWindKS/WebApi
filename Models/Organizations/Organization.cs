using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Data.Interfaces.Systems;
using WebAPI.Models.Addresses;
using WebAPI.Models.Finances;

namespace WebAPI.Models.Organizations;

[Table("Organization")]
public class Organization : IContainId
{
    public int Id { get; set; }

    public string NativeName { get; set; } = null!;

    public string ShortName { get; set; }

    public int? CountryId { get; set; }

    public string Skype { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public string Website { get; set; }

    public bool IsLead { get; set; }

    public int? OrganizationLegalFormId { get; set; }
    
    public int? ParentOrganizationId { get; set; }

    [ForeignKey("CountryId")]
    public Country Country { get; set; }

    [ForeignKey("OrganizationLegalFormId")]
    public OrganizationLegalForm OrganizationLegalForm { get; set; }

    [ForeignKey("ParentOrganizationId")]
    public Organization ParentOrganization { get; set; }

    public ICollection<OrganizationBankAccount> OrganizationBankAccounts { get; set; } = new HashSet<OrganizationBankAccount>();

    public ICollection<Organization> ChildOrganizations { get; set; } = new HashSet<Organization>();
}