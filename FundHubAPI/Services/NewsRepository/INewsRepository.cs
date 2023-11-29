using FundHubAPI.Data.Models;

namespace FundHubAPI.Services.NewsRepository;

public interface INewsRepository
{
    public Task CreateNewsFolders();
    public Task<List<News>> GetNews();
    public Task AddNews(News newstoadd);
    public Task UpdateNews(News newstoupdate);
    public Task RemoveNews(News newstoremove);
}