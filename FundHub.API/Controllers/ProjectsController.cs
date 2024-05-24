using FundHub.Data.Data.DTOs.RequestDTO;
using FundHub.Data.Data.DTOs.ResponseDTO;
using FundHub.Services.Services.Repositories.ProjectsRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FundHubAPI.Controllers;


[Route("Projects")]
public class ProjectsController : BaseController
{
    private readonly IProjectsRepository _projectsservice;

    public ProjectsController(IProjectsRepository projectsservice)
    {
        _projectsservice = projectsservice;
    }
    
    [HttpGet("GetProjects/{pagenumber?}")]
    public async Task<IActionResult> GetProjects(int? pagenumber)
    {
        int pageSize = 10;
        if (pagenumber == null)
        {
            List<ProjectResponseDTO> projects = await _projectsservice.GetProjects();
            return Ok(projects);
        }
        else
        {
            var projects = await _projectsservice.GetProjects();
            int totalPages = projects.Count / pageSize;
            var projectsRes = projects.Skip((int)((pagenumber - 1) * pageSize)).Take(pageSize).ToList();

            var response = new
            {
                totalPages,
                projects = projectsRes
            };
            return Ok(response);
        }
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