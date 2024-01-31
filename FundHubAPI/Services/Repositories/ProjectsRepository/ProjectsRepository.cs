using AutoMapper;
using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.Models;
using FundHubAPI.Services.Repositories;
using FundHubAPI.Services.Repositories.ProjectsRepository;
using Microsoft.EntityFrameworkCore;

namespace FundHubAPI.Data.Repositories;

class ProjectsRepository :  GenericRepository<Project>, IProjectsRepository
{
    
    public ProjectsRepository(DataContext db, IMapper mapper, IWebHostEnvironment hostingEnvironment) : base(db, mapper, hostingEnvironment)
    {
        
    }
    public async Task<List<Project>> GetProjectsOfCategory(string category)
    {
        return await _db.Projects.Where(x => x.category.name == category).ToListAsync();
    }

    public async Task CreateFolders()
    {
        try
        {
            List<Project> allprojects = await _db.Projects.ToListAsync();
            foreach (Project project in allprojects)
            {
                var productfoldertocreate = Path.Combine(_hostenv.ContentRootPath, "Storage", "Projects",
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

    public async Task<bool> CreateNewProject(ProjectRequestDTO newprojecttocreate)
    {
        Project newproject = _mapper.Map<Project>(newprojecttocreate);
        newproject.Id = Guid.NewGuid();
        var productfoldertocreate = Path.Combine(_hostenv.ContentRootPath, "Storage", "Projects", $"{newproject.Id}", "Images");
        Directory.CreateDirectory(productfoldertocreate); 
        foreach (var imagefile in newprojecttocreate.ImagesFiles)
        {
            newproject.images.Append(imagefile.FileName);
            var filetocreate = Path.Combine(_hostenv.ContentRootPath, "Storage", "Projects", $"{newproject.Id}", "Images", $"{imagefile.FileName}");
            var stream = new FileStream(filetocreate, FileMode.Create);
            await imagefile.CopyToAsync(stream);
        }
        var check = await AddDirect(newproject);
        return check;
    }
    
    
    /*
 
     public async Task<List<Project>> GetProjects()
{
    return await _db.Projects.ToListAsync();
}

public async Task<Project> GetProject(string projectid)
{
    Guid projectguid = Guid.Parse(projectid);
    return await _db.Projects.FirstAsync(x => x.Id == projectguid);
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

 */



}