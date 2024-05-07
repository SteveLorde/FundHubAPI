using FundHub.Data.Data.DTOs.ResponseDTO;
using FundHub.Services.Services.Repositories.NewsRepository;
using Microsoft.AspNetCore.Mvc;

namespace FundHubAPI.Controllers;

[Route("News")]
public class NewsController : BaseController
{
    private INewsRepository _newsrepo;

    public NewsController(INewsRepository newsrepo)
    {
        _newsrepo = newsrepo;
    }
    
    
    [HttpGet("GetNews")]
    public async Task<List<NewsResponseDTO>> GetNews()
    {
        return await _newsrepo.GetNews();
    }
    
    
    
}