using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.Models;
using FundHubAPI.Data.Repositories;

namespace FundHubAPI.Services.Projects;

public interface IProjectsRepository : IGenericRepository<Project>
{
    public Task<List<Project>> GetProjects();
    public Task<Project> GetProject(string projectid);
    public Task<List<Project>> GetProjectsOfCategory(string category);
    public Task CreateFolders();
    public Task<bool> CreateNewProject(ProjectDTO newproject);
    public Task<bool> UpdateProject(ProjectDTO projecttoupdate);
    public Task<bool> RemoveProject(string projectid);
}