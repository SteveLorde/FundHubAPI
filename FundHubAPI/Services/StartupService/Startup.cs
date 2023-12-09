using FundHubAPI.Services.NewsRepository;
using FundHubAPI.Services.Projects;

namespace FundHubAPI.Services.StartupService;

public class Startup
{
    private readonly IServiceProvider _serviceprovider;

    public Startup(IServiceProvider serviceProvider)
    {
        _serviceprovider = serviceProvider;
    }

    public void ExecuteServices()
    {
        var scope1 = _serviceprovider.CreateScope();
        var servicescoper1 = scope1.ServiceProvider;
        var newsservice = servicescoper1.GetRequiredService<INewsRepository>();
        newsservice.CreateNewsFolders();
        var scope2 = _serviceprovider.CreateScope();
        var servicescoper2 = scope2.ServiceProvider;
        var projectsservice = servicescoper2.GetRequiredService<IProjectService>();
        projectsservice.CreateFolders();
    }
        
        
}