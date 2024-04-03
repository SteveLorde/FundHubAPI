using FundHub.Data.Data.DTOs.ResponseDTO;

namespace FundHub.Services.Services.Repositories.CategoriesRepository;

public interface ICategoryRepository
{
    public Task<List<CategoryResponseDTO>> GetCategories();
}