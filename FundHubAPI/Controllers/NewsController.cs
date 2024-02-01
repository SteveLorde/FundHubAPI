using FundHubAPI.Data.Models;
using FundHubAPI.Services.Repositories.NewsRepository;
using Microsoft.AspNetCore.Mvc;

namespace FundHubAPI.Controllers;

/*
[Authorize]
*/
[ApiController]
[Route("News")]
public class NewsController : Controller
{
    private INewsRepository _newsrepo;

    public NewsController(INewsRepository newsrepo)
    {
        _newsrepo = newsrepo;
    }
    
    
    [HttpGet("GetNews")]
    public async Task<List<News>> GetNews()
    {
        return await _newsrepo.GetAll();
    }
    
    
    
}