using System.Text;
using System.Text.Json.Serialization;
using FundHubAPI.Services;
using FundHubAPI.Services.StartupService;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
//HttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
//string issuer = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}";

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});;
builder.Services.AddServices();
builder.Services.AddAuthentication().AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateLifetime = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["URL"],
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["secretkey"]))
        };
    });

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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run(builder.Configuration["URL"]);

