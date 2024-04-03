using FundHub.Data.Data;
using FundHub.Services.Services.Repositories.NewsRepository;
using FundHub.Services.Services.Repositories.ProjectsRepository;
using FundHub.Services.Services.Repositories.UsersRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FundHub.Services.Services.StartupService;

public class Startup
{
    private readonly IServiceProvider _serviceprovider;
    private readonly IWebHostEnvironment _webenv;

    public Startup(IServiceProvider serviceProvider, IWebHostEnvironment webenv)
    {
        _serviceprovider = serviceProvider;
        _webenv = webenv;
    }

    public void ExecuteServices()
    {
        var storagefolder = Path.Combine(_webenv.ContentRootPath, "Storage");
        Directory.CreateDirectory(storagefolder);
        var dbservice = _serviceprovider.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
        dbservice.Database.Migrate();
        
        var scope1 = _serviceprovider.CreateScope();
        var newsservice = scope1.ServiceProvider.GetRequiredService<INewsRepository>();
        newsservice.CreateNewsFolders();
        
        var scope2 = _serviceprovider.CreateScope();
        var projectsservice = scope2.ServiceProvider.GetRequiredService<IProjectsRepository>();
        projectsservice.CreateFolders();
        
        var scope3 = _serviceprovider.CreateScope();
        var usersservice = scope3.ServiceProvider.GetRequiredService<IUserRepository>();
        usersservice.CreateFolders();

    }
        
        
}