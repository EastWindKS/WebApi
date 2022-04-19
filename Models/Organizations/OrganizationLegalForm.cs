using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Data.Interfaces.Systems;
using WebAPI.Models.Addresses;

namespace WebAPI.Models.Organizations;

[Table("OrganizationLegalForm")]
public class OrganizationLegalForm : IContainId
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Explanation { get; set; }
    public int? CountryId { get; set; }

    [ForeignKey("CountryId")]
    public Country Country { get; set; }
}