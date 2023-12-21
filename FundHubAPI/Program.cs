using API.Services.Authentication;
using API.Services.JWT;
using FundHubAPI.Data;
using FundHubAPI.Services.Authentication;
using FundHubAPI.Services.AutoMapper;
using FundHubAPI.Services.JWT;
using FundHubAPI.Services.NewsRepository;
using FundHubAPI.Services.Projects;
using FundHubAPI.Services.StartupService;
using FundHubAPI.Services.Users;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IAuthentication,Authentication>();
builder.Services.AddScoped<IJWT,Jwt>();
builder.Services.AddScoped<IUsers,Users>();
builder.Services.AddScoped<IProjectService,ProjectService>();
builder.Services.AddScoped<INewsRepository,NewsRepository>();
builder.Services.AddScoped<Startup>();
builder.Services.AddAutoMapper(typeof(AutoProfile));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    });
});

var urlkey = builder.Configuration["URL"];

var app = builder.Build();

var servicescope = app.Services.CreateScope();
var services = servicescope.ServiceProvider;
var startupservice = services.GetRequiredService<Startup>();
startupservice.ExecuteServices();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "Storage")),
    RequestPath = "/storage"
});

app.UseAuthorization();

app.MapControllers();

app.Run();