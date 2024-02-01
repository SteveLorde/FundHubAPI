using FundHubAPI.Data;
using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.DTOs.RequestDTO;
using FundHubAPI.Data.Models;
using FundHubAPI.Services.Repositories.ProjectsRepository;
using FundHubAPI.Services.Repositories.UsersRepository;

namespace FundHubAPI.Services.Donate;

class Donate : IDonate
{
    private readonly IProjectsRepository _projectsrepo;
    private readonly IUserRepository _usersrepo;
    private readonly DataContext _db;

    public Donate(IProjectsRepository projectsrepo, IUserRepository usersrepo, DataContext db)
    {
        _projectsrepo = projectsrepo;
        _usersrepo = usersrepo;
        _db = db;
    }
    
    public async Task DonateToProject(DonationRequestDTO donationtolog)
    {
        var user = await _usersrepo.GetUser(donationtolog.userid);
        var project = await _projectsrepo.GetProjectDirect(donationtolog.projectid);
        DonationLog newdonationlog = new DonationLog
        {
            Id = Guid.NewGuid(), UserId = user.Id, User = user, ProjectId = project.Id, Project = project,
            donationamount = donationtolog.donationamount, datetime = donationtolog.date
        };
        await _db.DonationLogs.AddAsync(newdonationlog);
        await _db.SaveChangesAsync();
    }

}