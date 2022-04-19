namespace WebAPI.Dtos.Organizations;

public class OrganizationLegalFormDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Explanation { get; set; }

    public int? CountryId { get; set; }
}