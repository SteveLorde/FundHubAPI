using AutoMapper;
using FundHubAPI.Data;
using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.DTOs.RequestDTO;
using FundHubAPI.Data.Models;
using FundHubAPI.Services.Mail;
using FundHubAPI.Services.Repositories.ProjectsRepository;
using FundHubAPI.Services.Repositories.UsersRepository;

namespace FundHubAPI.Services.Donate;

class Donate : IDonate
{
    private readonly IProjectsRepository _projectsrepo;
    private readonly IUserRepository _usersrepo;
    private readonly DataContext _db;
    private readonly IMapper _mapper;
    private readonly IMail _mailservice;

    public Donate(IProjectsRepository projectsrepo, IMapper mapper ,IUserRepository usersrepo, DataContext db, IMail mailservice)
    {
        _projectsrepo = projectsrepo;
        _usersrepo = usersrepo;
        _db = db;
        _mapper = mapper;
        _mailservice = mailservice;
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
        await MailNotifyProjectOwner(project.User.Email, project, newdonationlog);
        await _db.SaveChangesAsync();
    }

    private async Task MailNotifyProjectOwner(string projectowneremail, Project project ,Donation donation)
    {
        string messagebody = $"Dear {project.User.Username}, your project {project.Title} has just received a donation of amount {donation.DonationAmount}";
        MailRequest projectownermailnotify = new MailRequest {Emailto = projectowneremail, Subject = "Received Donation", Message = messagebody};
        await _mailservice.SendMail(projectownermailnotify);
    }
    
    private async Task MailNotifyDonator(Donation donation,User donator ,Project project)
    {
        string messagebody = $"Dear {donator.Username}, you have just donated amount of {donation.DonationAmount} to project {project.Title}, Thank You for Supporting your community";
        MailRequest donatornotifymail = new MailRequest {Emailto = donator.Email , Subject = "Donation Accepted", Message = messagebody};
        await _mailservice.SendMail(donatornotifymail);
    }

}