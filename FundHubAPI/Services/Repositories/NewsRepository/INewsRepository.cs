using FundHubAPI.Data.DTOs.ResponseDTO;
using FundHubAPI.Data.Models;

namespace FundHubAPI.Services.Repositories.NewsRepository;

public interface INewsRepository
{
    public Task<List<NewsResponseDTO>> GetNews();
    public Task<NewsResponseDTO> GetNewsArticle(string newsid);
    public Task CreateNewsFolders();
    public Task AddNews(News newstoadd);

}