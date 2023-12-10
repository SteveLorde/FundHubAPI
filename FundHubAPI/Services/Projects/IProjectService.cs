using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.Models;

namespace FundHubAPI.Services.Projects;

public interface IProjectService
{
    public Task<List<Project>> GetProjects();
    public Task<List<Project>> GetProjectsOfCategory(string category);
    public Task CreateFolders();
    public Task<bool> CreateNewProject(ProjectDTO newproject);
    public Task<bool> UpdateProject(ProjectDTO projecttoupdate);
    public Task<bool> RemoveProject(string projectid);
}