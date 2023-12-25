using FundHubAPI.Data.Models;
using FundHubAPI.Data.Repositories;

namespace FundHubAPI.Services.NewsRepository;

public interface INewsRepository : IGenericRepository<News>
{
    public Task CreateNewsFolders();
    public Task AddNews(News newstoadd);

}