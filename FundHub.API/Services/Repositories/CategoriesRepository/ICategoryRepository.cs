using FundHubAPI.Data.DTOs.ResponseDTO;
using FundHubAPI.Data.Models;

namespace FundHubAPI.Services.Repositories.CategoriesRepository;

public interface ICategoryRepository
{
    public Task<List<CategoryResponseDTO>> GetCategories();
}