using FundHub.Data.Data.DTOs.RequestDTO;
using FundHub.Data.Data.DTOs.ResponseDTO;
using FundHub.Services.Services.Repositories.ProjectsRepository;
using Microsoft.AspNetCore.Authorization;
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
    
    [Authorize]
    [HttpPost("AddProject")]
    public async Task<bool> AddProject(ProjectRequestDTO projecttoadd)
    {
        var authheader = HttpContext.Request.Headers["Authorization"];
        string token = "";
        if (authheader.ToString().StartsWith("Bearer"))
        {
            token = authheader.ToString().Substring("Bearer ".Length).Trim();
        }
        if (!string.IsNullOrEmpty(token))
        {
            return await _projectsservice.AddProject(projecttoadd);
        }
        else
        {
            return false;
        }
    }
    
    [Authorize]
    [HttpPost("UpdateProject")]
    public async Task<bool> UpdateProject(ProjectRequestDTO projecttoadd)
    {
        return await _projectsservice.UpdateProject(projecttoadd);
    }
    
    [Authorize]
    [HttpPost("RemoveProject")]
    public async Task<bool> RemoveProject(string projectid)
    {
        return await _projectsservice.RemoveProject(projectid);
    }
    
    
    
}