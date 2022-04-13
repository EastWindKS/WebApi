using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.Finances;

[Table("Currency")]
public class Currency
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ISOName { get; set; } = null!;

    public string Symbol { get; set; } = null!;

    public string ISOCode { get; set; } = null!;

    public string ISODigitCode { get; set; } = null!;

    public string MonetaryUnit { get; set; } = null!;

    public bool IsAccountingCurrency { get; set; }

    public int? DefaultInCountryId { get; set; }
}