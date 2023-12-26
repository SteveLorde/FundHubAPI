using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.Models;
using FundHubAPI.Data.Repositories;

namespace FundHubAPI.Services.Repositories.ProjectsRepository;

public interface IProjectsRepository : IGenericRepository<Project>
{
    public Task<Project> GetProjectDetails(string projectid);
    public Task<List<Project>> GetProjectsOfCategory(string category);
    public Task CreateFolders();
    public Task<bool> CreateNewProject(ProjectDTO projecttoadd);
}