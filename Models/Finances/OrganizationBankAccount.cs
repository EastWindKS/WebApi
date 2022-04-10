using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Models.Organizations;

namespace WebAPI.Models.Finances;

[Table("OrganizationBankAccount")]
public class OrganizationBankAccount
{
    public int Id { get; set; }

    public int OrganizationId { get; set; }

    public int BankId { get; set; }

    public int CurrencyId { get; set; }

    public string Name { get; set; }

    public string IBAN { get; set; }

    public DateTime? DateBegin { get; set; }

    public DateTime? DateEnd { get; set; }

    public bool IsCash { get; set; }

    [ForeignKey("OrganizationId")]
    public Organization Organization { get; set; }

    [ForeignKey("BankId")]
    public Bank Bank { get; set; }

    [ForeignKey("CurrencyId")]
    public Currency Currency { get; set; }
}