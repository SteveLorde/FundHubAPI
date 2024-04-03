using Microsoft.AspNetCore.Http;

namespace FundHub.Data.Data.DTOs.RequestDTO;

public class ProjectUpdateDTO
{
    public Guid Id = Guid.NewGuid();
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public Guid? UserId { get; set; }
    public int Totalfundrequired { get; set; }
    public string facebook { get; set; }
    public string x { get; set; }
    public string instagram { get; set; }
    public IFormFile[] ImagesFiles { get; set; }
    public bool IsAccepted { get; set; }
}