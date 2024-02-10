namespace FundHubAPI.Data.DTOs.RequestDTO;

public class ProjectRequestDTO
{
    public Guid Id = Guid.NewGuid();
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public Guid? UserId { get; set; }
    public int Totalfundrequired { get; set; }
    public string Facebook { get; set; }
    public string X { get; set; }
    public string Instagram { get; set; }
    public IFormFile[] ImagesFiles { get; set; }
    public bool IsAccepted { get; set; }
}