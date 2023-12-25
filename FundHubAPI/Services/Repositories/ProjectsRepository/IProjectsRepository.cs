using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.Models;

namespace FundHubAPI.Data.Repositories;

public interface IProjectsRepository : IGenericRepository<Project>
{
    public Task<List<Project>> GetProjectsOfCategory(string category);
    public Task CreateFolders();
    public Task<bool> CreateNewProject(ProjectDTO projecttoadd);
}