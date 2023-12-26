using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.Models;
using FundHubAPI.Data.Repositories;
using FundHubAPI.Services.Repositories.ProjectsRepository;
using Microsoft.AspNetCore.Mvc;

namespace FundHubAPI.Controllers;

[ApiController]
[Route("Projects")]
public class ProjectsController : Controller
{
    private readonly IProjectsRepository _projectsservice;

    public ProjectsController(IProjectsRepository projectsservice)
    {
        _projectsservice = projectsservice;
    }
    
    [HttpGet("GetProjects")]
    public async Task<List<Project>> GetProjects()
    {
        return await _projectsservice.GetAll(x => x.category);
    }
    
    [HttpGet("GetProject/{projectid}")]
    public async Task<Project> GetProject(string projectid)
    { 
        return await _projectsservice.Get(projectid, e => e.User, e => e.category);
    }
    
    [HttpPost("AddProject")]
    public async Task<bool> AddProject(ProjectDTO projecttoadd)
    {
        return await _projectsservice.CreateNewProject(projecttoadd);
    }
    
    [HttpPost("UpdateProject")]
    public async Task<bool> UpdateProject(ProjectDTO projecttoadd)
    {
        return await _projectsservice.Update(projecttoadd);
    }
    
    [HttpPost("RemoveProject")]
    public async Task<bool> RemoveProject(string projectid)
    {
        return await _projectsservice.Remove(projectid);
    }
    
    
    
}