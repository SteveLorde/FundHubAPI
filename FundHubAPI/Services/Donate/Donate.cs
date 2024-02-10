using AutoMapper;
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
    private readonly IMapper _mapper;

    public Donate(IProjectsRepository projectsrepo, IMapper mapper ,IUserRepository usersrepo, DataContext db)
    {
        _projectsrepo = projectsrepo;
        _usersrepo = usersrepo;
        _db = db;
        _mapper = mapper;
    }
    
    public async Task DonateToProject(DonationRequestDTO donationtolog)
    {
        var user = await _usersrepo.GetUser(donationtolog.UserId.ToString());
        var project = await _projectsrepo.GetProjectDirect(donationtolog.ProjectId.ToString());
        Donation newdonationlog = new Donation
        {
            Id = Guid.NewGuid(), UserId = user.Id, User = _mapper.Map<User>(user), ProjectId = project.Id, Project = project,
            DonationAmount = donationtolog.DonationAmount, Date = donationtolog.Date
        };
        await _db.DonationLogs.AddAsync(newdonationlog);
        await _db.SaveChangesAsync();
    }

}