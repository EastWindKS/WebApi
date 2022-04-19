using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Data.Interfaces.Systems;

namespace WebAPI.Models.Finances;

[Table("Currency")]
public class Currency : IContainId
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string ISOName { get; set; }

    public string Symbol { get; set; }

    public string ISOCode { get; set; }

    public bool IsAccountingCurrency { get; set; }

    public int? DefaultInCountryId { get; set; }
}