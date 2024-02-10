using AutoMapper;
using AutoMapper.QueryableExtensions;
using FundHubAPI.Data;
using FundHubAPI.Data.DTOs.ResponseDTO;
using FundHubAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FundHubAPI.Services.Repositories.CategoriesRepository;

class CategoryRepository : ICategoryRepository
{
    private readonly IWebHostEnvironment _hostenv;
    private readonly IMapper _mapper;
    private readonly DataContext _db;

    public CategoryRepository(DataContext db, IMapper mapper, IWebHostEnvironment hostingEnvironment)
    {
        _db = db;
        _mapper = mapper;
        _hostenv = hostingEnvironment;
    }


    public async Task<List<CategoryResponseDTO>> GetCategories()
    {
        return await _db.Categories.ProjectTo<CategoryResponseDTO>(_mapper.ConfigurationProvider).ToListAsync();
    }
}