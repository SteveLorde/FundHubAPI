using AutoMapper;
using FundHubAPI.Data;
using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FundHubAPI.Services.Projects;

class ProjectService : IProjectService
{
    private readonly DataContext _db;
    private readonly IWebHostEnvironment _hostingenv;
    private readonly IMapper _mapper;

    public ProjectService(DataContext db, IWebHostEnvironment hostenv, IMapper mapper)
    {
        _db = db;
        _hostingenv = hostenv;
        _mapper = mapper;
    }
    
    public async Task<List<Project>> GetProjects()
    {
        return await _db.Projects.ToListAsync();
    }

    public async Task<Project> GetProject(string projectid)
    {
        Guid projectguid = Guid.Parse(projectid);
        return await _db.Projects.FirstAsync(x => x.Id == projectguid);
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

    public async Task<bool> CreateNewProject(ProjectDTO newprojecttocreate)
    {
        Project newproject = _mapper.Map<Project>(newprojecttocreate);
        await _db.Projects.AddAsync(newproject);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateProject(ProjectDTO projecttoupdate)
    {
        var selectedproject = await _db.Projects.FirstAsync(x => x.Id == projecttoupdate.Id);
        selectedproject = _mapper.Map<Project>(projecttoupdate);
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