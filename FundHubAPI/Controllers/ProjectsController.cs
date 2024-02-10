using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.DTOs.RequestDTO;
using FundHubAPI.Data.DTOs.ResponseDTO;
using FundHubAPI.Data.Models;
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
    public async Task<List<ProjectResponseDTO>> GetProjects()
    {
        return await _projectsservice.GetProjects();
    }
    
    [HttpGet("GetProject/{projectid}")]
    public async Task<ProjectResponseDTO> GetProject(string projectid)
    { 
        return await _projectsservice.GetProject(projectid);
    }
    
    [HttpPost("AddProject")]
    public async Task<bool> AddProject(ProjectRequestDTO projecttoadd)
    {
        return await _projectsservice.AddProject(projecttoadd);
    }
    
    [HttpPost("UpdateProject")]
    public async Task<bool> UpdateProject(ProjectRequestDTO projecttoadd)
    {
        return await _projectsservice.UpdateProject(projecttoadd);
    }
    
    [HttpPost("RemoveProject")]
    public async Task<bool> RemoveProject(string projectid)
    {
        return await _projectsservice.RemoveProject(projectid);
    }
    
    
    
}