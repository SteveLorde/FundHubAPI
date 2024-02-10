using FundHubAPI.Data.Models;
using FundHubAPI.Services.Repositories.CategoriesRepository;
using FundHubAPI.Services.Repositories.NewsRepository;
using Microsoft.AspNetCore.Mvc;

namespace FundHubAPI.Controllers;

[ApiController]
[Route("Categories")]
public class CategoriesController : Controller
{
    private INewsRepository _newsrepo;
    private readonly ICategoryRepository _categoryrepo;

    public CategoriesController(ICategoryRepository categoryrepo)
    {
        _categoryrepo = categoryrepo;
    }
    
    [HttpGet("GetCategories")]
    public async Task<List<Category>> GetCategories()
    {
        return await _categoryrepo.GetCategories();
    }
    
    
    
}