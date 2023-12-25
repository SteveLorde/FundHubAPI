using FundHubAPI.Data.Models;

namespace FundHubAPI.Data.Repositories;

public interface INewsRepository : IGenericRepository<News>
{
    public Task CreateNewsFolders();
    public Task AddNews(News newstoadd);

}