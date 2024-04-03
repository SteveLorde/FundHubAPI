using FundHub.Data.Data.DTOs.RequestDTO;
using FundHub.Data.Data.DTOs.ResponseDTO;
using FundHub.Data.Data.Models;

namespace FundHub.Services.Services.Repositories.ProjectsRepository;

public interface IProjectsRepository
{
    public Task<List<ProjectResponseDTO>> GetProjects();
    //public Task<List<Project>> GetProjectsOfCategory(string categoryid);
    public Task<ProjectResponseDTO> GetProject(string projectid);
    public Task<Project> GetProjectDirect(string projectid);

    public Task<bool> AddProject(ProjectRequestDTO projecttoadd);
    public Task<bool> UpdateProject(ProjectRequestDTO projecttoupdate);
    public Task<bool> RemoveProject(string projectid);

    public Task CreateFolders();
}