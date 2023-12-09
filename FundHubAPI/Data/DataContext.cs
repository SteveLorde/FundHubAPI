using FundHubAPI.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace FundHubAPI.Data;

public class DataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=FundHub;Username=postgres;Password=World2050");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<News>().HasData(
            new News { Id = Guid.Parse("0f97ea1d-e247-4cf5-a6d9-5f9d3265e220"), title = "Innovative Breakthroughs: College Students Secure Funding for Groundbreaking Projects", subtitle = null, description = "Desc Test", published = new DateOnly(2024,1,1), image = "newscover.jpg"},
            new News { Id = Guid.Parse("1a55b12e-65b8-4542-b4c1-6676c30311e7"), title = "Empowering Tomorrow's Leaders: College Projects Receive Major Funding Boost", subtitle = null, description = "Desc Test", published = new DateOnly(2024,1,1), image = "newscover.jpg" },
            new News { Id = Guid.Parse("93097c20-6558-4ed9-a27e-8bf07fb59b8a"), title = "From Campus to Capital: Student-Led Ventures Garner Investment for Impactful Initiatives", subtitle = null, description = "Desc Test", published = new DateOnly(2024,1,1), image = "newscover.jpg" },
            new News { Id = Guid.Parse("598004de-bc37-4300-8271-3c1c0bb5c430"), title = "Shaping the Future: College Students' Ambitious Projects Win Substantial Funding", subtitle = null, description = "Desc Test", published = new DateOnly(2024,1,1), image = "newscover.jpg" }
        );
        
        modelBuilder.Entity<Project>().HasData(
            new Project { Id = Guid.Parse("7e4788cd-77a9-4b03-9412-385a482cf489"), title = "Greener Egypt", subtitle = "Subtitle Test", description = "Description Test", category = "enviornment", UserId = Guid.Empty, currentfund = 500, totalfundrequired = 2000,images = new string[] {"1.jpg", "2.jpg" } },
            new Project { Id = Guid.Parse("694d6683-d3e6-4bc1-ab5d-f2f67f887332"), title = "My Super Awesome Health Machine", subtitle = "Subtitle Test", description = "Description Test", category = "health", currentfund = 500, totalfundrequired = 1000000, UserId = Guid.Empty, images = new string[] {"1.jpg", "2.jpg" } },
            new Project { Id = Guid.Parse("a9437a37-1d37-4a9b-adbd-a18ef0490942"), title = "Electric Koshary Machine", subtitle = "Subtitle Test", description = "Description Test", category = "enviornment", currentfund = 500, totalfundrequired = 120000, UserId = Guid.Empty, images = new string[] {"1.jpg", "2.jpg" } },
            new Project { Id = Guid.Parse("e9c8eccf-76aa-42d6-be67-803d8622c951"), title = "Indie Egyptian Game", subtitle = "Subtitle Test", description = "Description Test", category = "enviornment", UserId = Guid.Empty, currentfund = 500, totalfundrequired = 60000, images = new string[] {"1.jpg", "2.jpg" } }
        );

        modelBuilder.Entity<User>().HasData(
            new User
            { Id = Guid.NewGuid(), username = "testuser", password = "1234", pass_salt = null, hashedpassword = null, usertype = "user", phonenumber = 123456789, email = "test@gmail.com" }
        );

    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<FundLogs> PurchaseLogs { get; set; }
}