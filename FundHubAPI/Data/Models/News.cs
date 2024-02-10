using System.ComponentModel.DataAnnotations;

namespace FundHubAPI.Data.Models;

public class News
{
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Description { get; set; }
    public DateOnly Published { get; set; }
    public string ImageCoverName { get; set; }
    
}