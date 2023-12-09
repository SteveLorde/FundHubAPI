using AutoMapper;
using FundHubAPI.Data;
using FundHubAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FundHubAPI.Services.NewsRepository;

class NewsRepository : INewsRepository
{
    
    private readonly DataContext _db;
    private readonly IWebHostEnvironment _hostenv;

    public NewsRepository(DataContext db, IWebHostEnvironment hostingEnvironment)
    {
        _db = db;
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
    
    public async Task<List<News>> GetNews()
    {
        return await _db.News.ToListAsync();
    }

    public async Task AddNews(News newstoadd)
    {
        await _db.News.AddAsync(newstoadd);
    }

    public async Task UpdateNews(News newstoupdate)
    {
        News selectednews = await _db.News.FirstAsync(x => x.Id == newstoupdate.Id);
        selectednews = newstoupdate;
        await _db.SaveChangesAsync();
    }

    public async Task RemoveNews(News newstoremove)
    {
        News selectednews = await _db.News.FirstAsync(x => x.Id == newstoremove.Id);
        _db.News.Remove(selectednews);
        await _db.SaveChangesAsync();
    }
    
}