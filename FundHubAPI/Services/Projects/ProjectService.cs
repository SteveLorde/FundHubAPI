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

    public async Task<bool> CreateNewProject(Project newproject)
    {
        await _db.Projects.AddAsync(newproject);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateProject(Project projecttoupdate)
    {
        var selectedproject = await _db.Projects.FirstAsync(x => x.Id == projecttoupdate.Id);
        {
            selectedproject.category = projecttoupdate.category;
            selectedproject.title = projecttoupdate.title;
            selectedproject.currentfund = projecttoupdate.currentfund;
            selectedproject.totalfundrequired = projecttoupdate.totalfundrequired;
            selectedproject.description = projecttoupdate.description;
            selectedproject.images = projecttoupdate.images;
        }
        _db.Projects.Update(selectedproject);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemoveProject(string projectid)
    {
        var projectguid = Guid.Parse(projectid);
        var selectedproject = await _db.Projects.FirstAsync(x => x.Id == projectguid);
        _db.Projects.Remove(selectedproject);
        await _db.SaveChangesAsync();
        return true;
    }
}