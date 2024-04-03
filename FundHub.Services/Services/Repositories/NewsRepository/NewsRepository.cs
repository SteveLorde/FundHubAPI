using AutoMapper;
using AutoMapper.QueryableExtensions;
using FundHub.Data.Data;
using FundHub.Data.Data.DTOs.ResponseDTO;
using FundHub.Data.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace FundHub.Services.Services.Repositories.NewsRepository;

public class NewsRepository : INewsRepository
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

    public async Task<List<NewsResponseDTO>> GetNews()
    {
        return await _db.News.ProjectTo<NewsResponseDTO>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<NewsResponseDTO> GetNewsArticle(string newsid)
    {
        return await _db.News.ProjectTo<NewsResponseDTO>(_mapper.ConfigurationProvider).FirstAsync(n => n.Id == Guid.Parse(newsid));
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