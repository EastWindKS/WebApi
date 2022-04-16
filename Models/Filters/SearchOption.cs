using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Data.Interfaces.Systems;

namespace WebAPI.Models.Filters;

[Table("SearchOption")]
public class SearchOption : IContainId
{
    public int Id { get; set; }

    public string Title { get; set; }
}