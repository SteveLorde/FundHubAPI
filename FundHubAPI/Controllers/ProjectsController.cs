using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.Models;
using FundHubAPI.Services.NewsRepository;
using FundHubAPI.Services.Projects;
using Microsoft.AspNetCore.Mvc;

namespace FundHubAPI.Controllers;

/*
[Authorize]
*/
[ApiController]
[Route("Projects")]
public class ProjectsController : Controller
{
    private readonly IProjectService _projectsservice;

    public ProjectsController(IProjectService projectsservice)
    {
        _projectsservice = projectsservice;
    }
    
    
    [HttpGet("GetProjects")]
    public async Task<List<Project>> GetProjects()
    {
        return await _projectsservice.GetProjects();
    }
    
        [HttpGet("GetProject/{projectid}")]
        public async Task<Project> GetProject(string projectid)
        {
            return await _projectsservice.GetProject(projectid);
        }
    
    [HttpPost("AddProject")]
    public async Task<bool> AddProject(ProjectDTO projecttoadd)
    {
        return await _projectsservice.CreateNewProject(projecttoadd);
    }
    
    [HttpPost("UpdateProject")]
    public async Task<bool> UpdateProject(ProjectDTO projecttoadd)
    {
        return await _projectsservice.UpdateProject(projecttoadd);
    }
    
        [HttpPost("RemoveProject")]
    public async Task<bool> RemoveProject(string projectid)
    {
        return await _projectsservice.RemoveProject(projectid);
    }
    
    
    
}