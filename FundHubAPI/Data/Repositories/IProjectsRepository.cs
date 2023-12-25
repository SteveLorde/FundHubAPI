using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.Models;
using FundHubAPI.Data.Repositories;

namespace FundHubAPI.Services.Projects;

public interface IProjectsRepository : IGenericRepository<Project>
{
    public Task<List<Project>> GetProjectsOfCategory(string category);
    public Task CreateFolders();
    public Task<bool> CreateNewProject(ProjectDTO projecttoadd);
}