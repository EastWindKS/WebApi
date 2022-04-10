using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Data.Interfaces.Systems;

namespace WebAPI.Models.Addresses;

[Table("Country")]
public class Country : IContainId
{
    public int Id { get; set; }

    public string Alfa3Code { get; set; }

    public string IsoCode { get; set; }

    public string Name { get; set; }

    public string InternationalName { get; set; }
}