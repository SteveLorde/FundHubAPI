using FundHubAPI.Data.Models;

namespace FundHubAPI.Services.Projects;

public interface IProjectService
{
    public Task<List<Project>> GetProjects();
    public Task<List<Project>> GetProjectsOfCategory(string category);
    public Task CreateFolders();
    public Task CreateNewProject();
    public Task UpdateProject();
    public Task RemoveProject();
}