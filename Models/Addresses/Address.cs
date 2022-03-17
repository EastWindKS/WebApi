using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.Addresses;

[Table("Address")]
public class Address
{
    public int Id { get; set; }

    public int? CountryId { get; set; }

    public string PostIndex { get; set; }

    public string RegionName { get; set; }

    public string LocalityName { get; set; }

    public string VillageName { get; set; }

    public string PlaceName { get; set; }

    public short? BuildingNumber { get; set; }

    public string Housing { get; set; }

    public string Apartment { get; set; }

    public byte? LocalityId { get; set; }

    public byte? VillageId { get; set; }

    public byte? PlaceId { get; set; }

    public int? RegionId { get; set; }

    public int? CityId { get; set; }
}