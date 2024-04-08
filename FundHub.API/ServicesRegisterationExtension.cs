using FundHub.Data.Data;
using FundHub.Services.Services.Authentication;
using FundHub.Services.Services.AutoMapper;
using FundHub.Services.Services.JWT;
using FundHub.Services.Services.Mail;
using FundHub.Services.Services.PasswordHash;
using FundHub.Services.Services.Repositories.CategoriesRepository;
using FundHub.Services.Services.Repositories.NewsRepository;
using FundHub.Services.Services.Repositories.ProjectsRepository;
using FundHub.Services.Services.Repositories.UsersRepository;
using FundHub.Services.Services.StartupService;

namespace FundHubAPI;

public static class ServicesRegisterationExtension
{
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<DataContext>();
        serviceCollection.AddHttpContextAccessor();
        serviceCollection.AddScoped<IPasswordHash, PasswordHash>();
        serviceCollection.AddScoped<IAuthentication,Authentication>();
        serviceCollection.AddScoped<IJWT,Jwt>();
        serviceCollection.AddScoped<IUserRepository,UserRepository>();
        serviceCollection.AddScoped<IMail,Mail>();
        serviceCollection.AddScoped<IProjectsRepository,ProjectsRepository>();
        serviceCollection.AddScoped<ICategoryRepository,CategoryRepository>();
        serviceCollection.AddScoped<INewsRepository,NewsRepository>();
        serviceCollection.AddScoped<IUserRepository,UserRepository>();
        serviceCollection.AddScoped<Startup>();
        serviceCollection.AddAutoMapper(typeof(AutoProfile));
    }
}