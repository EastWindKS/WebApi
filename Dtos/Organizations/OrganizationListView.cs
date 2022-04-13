namespace WebAPI.Dtos.Organizations;

public class OrganizationListView
{
    public int Id { get; set; }

    public string NativeName { get; set; }

    public string Country { get; set; }

    public string Managers { get; set; }

    public string Offices { get; set; }
}