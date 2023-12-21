using FundHubAPI.Services.NewsRepository;
using FundHubAPI.Services.Projects;
using FundHubAPI.Services.Users;

namespace FundHubAPI.Services.StartupService;

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
        var scope1 = _serviceprovider.CreateScope();
        var servicescoper1 = scope1.ServiceProvider;
        var newsservice = servicescoper1.GetRequiredService<INewsRepository>();
        newsservice.CreateNewsFolders();
        var scope2 = _serviceprovider.CreateScope();
        var servicescoper2 = scope2.ServiceProvider;
        var projectsservice = servicescoper2.GetRequiredService<IProjectService>();
        projectsservice.CreateFolders();
        var scope3 = _serviceprovider.CreateScope();
        var servicescoper3 = scope3.ServiceProvider;
        var usersservice = servicescoper3.GetRequiredService<IUsers>();
        usersservice.CreateFolders();

    }
        
        
}