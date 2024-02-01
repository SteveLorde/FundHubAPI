using AutoMapper;
using FundHubAPI.Data;
using FundHubAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FundHubAPI.Services.Repositories.NewsRepository;

class NewsRepository : INewsRepository
{
    private readonly DataContext _db;
    private readonly IWebHostEnvironment _hostenv;
    private readonly IMapper _mapper;

    public NewsRepository(DataContext db, IMapper mapper, IWebHostEnvironment hostingEnvironment)
    {
        _db = db;
        _hostenv = hostingEnvironment;
        _mapper = mapper;
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