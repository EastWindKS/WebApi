using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.Finances;

[Table("Bank")]
public class Bank
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string CorrespondentAccount { get; set; }

    public string SwiftCode { get; set; }

    public string NationalCode { get; set; }

    public int OrganizationId { get; set; }
}