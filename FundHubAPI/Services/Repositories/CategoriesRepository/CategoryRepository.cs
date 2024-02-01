using AutoMapper;
using FundHubAPI.Data;
using FundHubAPI.Data.Models;

namespace FundHubAPI.Services.Repositories.CategoriesRepository;

class CategoryRepository : ICategoryRepository
{
    public CategoryRepository(DataContext db, IMapper mapper, IWebHostEnvironment hostingEnvironment)
    {
        
    }
    
    
}