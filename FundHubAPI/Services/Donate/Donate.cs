using AutoMapper;
using AutoMapper.QueryableExtensions;
using FundHubAPI.Data;
using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.DTOs.RequestDTO;
using FundHubAPI.Data.DTOs.ResponseDTO;
using FundHubAPI.Data.Models;
using FundHubAPI.Services.Mail;
using FundHubAPI.Services.Repositories.ProjectsRepository;
using FundHubAPI.Services.Repositories.UsersRepository;
using Microsoft.EntityFrameworkCore;

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

    public async Task<List<DonationResponseDTO>> GetDonations()
    {
        return await _db.DonationLogs.ProjectTo<DonationResponseDTO>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<bool> DecideDonation(string donationid, bool decision)
    {
        Donation querieddonationlog = await _db.DonationLogs.Include(d => d.Project).Include(d => d.User).FirstAsync(d => d.Id == Guid.Parse(donationid));
        Project queriedproject = await _projectsrepo.GetProjectDirect(querieddonationlog.ProjectId.ToString());
        User donator = await _db.Users.FirstAsync(u => u.Id == querieddonationlog.UserId);

        if (decision)
        {
            querieddonationlog.Status = true;
            _db.DonationLogs.Update(querieddonationlog);
            await _db.SaveChangesAsync();
            await MailNotifyApproveDonator(querieddonationlog, donator, queriedproject);
            return true;
        }
        else if (!decision)
        {
            querieddonationlog.Status = false;
            _db.DonationLogs.Update(querieddonationlog);
            await _db.SaveChangesAsync();
            await MailNotifyRejectDonator(querieddonationlog, donator, queriedproject);
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> DonateToProject(DonationRequestDTO donationtolog)
    {
        User user = await _usersrepo.GetUserDirect(donationtolog.UserId.ToString());
        Project project = await _projectsrepo.GetProjectDirect(donationtolog.ProjectId.ToString());
        Donation newdonationlog = new Donation
        {
            Id = donationtolog.Id , UserId = user.Id, User = user, ProjectId = project.Id, Project = project,
            Donationamount = donationtolog.DonationAmount, Date = donationtolog.Date
        };
        await _db.DonationLogs.AddAsync(newdonationlog);
        await MailNotifyProjectOwner(project.User.Email, project, newdonationlog);
        await _db.SaveChangesAsync();
        return true;
    }

    private async Task MailNotifyProjectOwner(string projectowneremail, Project project ,Donation donation)
    {
        string messagebody = $"Dear {project.User.Username}, your project {project.Title} has just received a donation of amount {donation.Donationamount}";
        MailRequest projectownermailnotify = new MailRequest {Emailto = projectowneremail, Subject = "Received Donation", Message = messagebody};
        await _mailservice.SendMail(projectownermailnotify);
    }
    
    private async Task MailNotifyApproveDonator(Donation donation,User donator ,Project project)
    {
        string messagebody = $"Dear {donator.Username}, you have just donated amount of {donation.Donationamount} to project {project.Title}, Thank You for Supporting your community";
        MailRequest donatornotifymail = new MailRequest {Emailto = donator.Email , Subject = "Donation Accepted", Message = messagebody};
        await _mailservice.SendMail(donatornotifymail);
    }
    
    private async Task MailNotifyRejectDonator(Donation donation,User donator ,Project project)
    {
        string messagebody = $"Dear {donator.Username}, your donation of {donation.Donationamount} to project {project.Title}, has been rejected. Please try again at different time";
        MailRequest donatornotifymail = new MailRequest {Emailto = donator.Email , Subject = "Donation Rejected", Message = messagebody};
        await _mailservice.SendMail(donatornotifymail);
    }

}