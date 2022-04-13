using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Models.Addresses;

namespace WebAPI.Models.Organizations;

[Table("OrganizationLegalForm")]
public class OrganizationLegalForm
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    
    public int? CountryId { get; set; }

    [ForeignKey("CountryId")]
    public Country Country { get; set; }
}