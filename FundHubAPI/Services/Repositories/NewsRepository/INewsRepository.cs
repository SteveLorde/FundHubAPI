using FundHubAPI.Data.Models;

namespace FundHubAPI.Services.Repositories.NewsRepository;

public interface INewsRepository
{
    public Task CreateNewsFolders();
    public Task AddNews(News newstoadd);

}