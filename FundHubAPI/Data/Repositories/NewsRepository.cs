using AutoMapper;
using FundHubAPI.Data;
using FundHubAPI.Data.Models;
using FundHubAPI.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FundHubAPI.Services.NewsRepository;

class NewsRepository : GenericRepository<News>,INewsRepository
{
    
    private readonly IWebHostEnvironment _hostenv;

    public NewsRepository(DataContext db, IWebHostEnvironment hostingEnvironment)
    {
        _hostenv = hostingEnvironment;
    }
    
    public async Task CreateNewsFolders()
    {
        try
        {
            List<News> allnews = await _db.News.ToListAsync();
            foreach (News news in allnews)
            {
                var newsfoldertocreate = Path.Combine(_hostenv.ContentRootPath, "Storage", "News",
                    $"{news.Id}", "Images");
                Directory.CreateDirectory(newsfoldertocreate); 
            }
            Console.WriteLine("Created News folders successfully");
        }
        catch (Exception err)
        {
            throw err;
        }
    }

    public async Task AddNews(News newstoadd)
    {
        await _db.News.AddAsync(newstoadd);
    }

    
}