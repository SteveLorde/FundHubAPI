using AutoMapper;
using FundHubAPI.Data;
using FundHubAPI.Data.Models;
using FundHubAPI.Data.Repositories;

namespace FundHubAPI.Services.Repositories.CategoriesRepository;

class CategoryRepository : GenericRepository<Category>,ICategoryRepository
{
    public CategoryRepository(DataContext db, IMapper mapper, IWebHostEnvironment hostingEnvironment) : base(db, mapper, hostingEnvironment)
    {
        
    }
    
    
}