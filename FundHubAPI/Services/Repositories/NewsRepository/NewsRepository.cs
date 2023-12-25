using AutoMapper;
using FundHubAPI.Data.Models;
using FundHubAPI.Services.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FundHubAPI.Data.Repositories;

class NewsRepository : GenericRepository<News>,INewsRepository
{
    
    public NewsRepository(DataContext db, IMapper mapper, IWebHostEnvironment hostingEnvironment) : base(db, mapper, hostingEnvironment)
    {
        
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