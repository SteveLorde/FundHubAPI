using FundHubAPI.Data;
using FundHubAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FundHubAPI.Services.Projects;

class ProjectService : IProjectService
{
    private readonly DataContext _db;
    private readonly IWebHostEnvironment _hostingenv;

    public ProjectService(DataContext db, IWebHostEnvironment hostenv)
    {
        _db = db;
        _hostingenv = hostenv;
    }
    
    public async Task<List<Project>> GetProjects()
    {
        return await _db.Projects.ToListAsync();
    }

    public async Task<List<Project>> GetProjectsOfCategory(string category)
    {
        return await _db.Projects.Where(x => x.category == category).ToListAsync();
    }

    public async Task CreateFolders()
    {
        try
        {
            List<Project> allprojects = await _db.Projects.ToListAsync();
            foreach (Project project in allprojects)
            {
                var productfoldertocreate = Path.Combine(_hostingenv.ContentRootPath, "Storage", "Projects",
                    $"{project.Id}", "Images");
                Directory.CreateDirectory(productfoldertocreate); 
            }
            Console.WriteLine("Created Products assets folders successfully");
        }
        catch (Exception err)
        {
            throw err;
        }
    }

    public async Task CreateNewProject()
    {
        throw new NotImplementedException();
    }

    public async Task UpdateProject()
    {
        throw new NotImplementedException();
    }

    public async Task RemoveProject()
    {
        throw new NotImplementedException();
    }
}