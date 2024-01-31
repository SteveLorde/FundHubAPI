namespace FundHubAPI.Data.DTOs;

public class ProjectRequestDTO
{
    public Guid Id = Guid.NewGuid();
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public Guid? UserId { get; set; }
    public int Totalfundrequired { get; set; }
    public IFormFile[] ImagesFiles { get; set; }
    public bool IsAccepted { get; set; }
}