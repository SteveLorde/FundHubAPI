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
            new News { Id = Guid.NewGuid(), title = "Innovative Breakthroughs: College Students Secure Funding for Groundbreaking Projects", subtitle = null, description = "Desc Test", published = new DateOnly(2024,1,1), image = "newscover.jpg"},
            new News { Id = Guid.NewGuid(), title = "Empowering Tomorrow's Leaders: College Projects Receive Major Funding Boost", subtitle = null, description = "Desc Test", published = new DateOnly(2024,1,1), image = "newscover.jpg" },
            new News { Id = Guid.NewGuid(), title = "From Campus to Capital: Student-Led Ventures Garner Investment for Impactful Initiatives", subtitle = null, description = "Desc Test", published = new DateOnly(2024,1,1), image = "newscover.jpg" },
            new News { Id = Guid.NewGuid(), title = "Shaping the Future: College Students' Ambitious Projects Win Substantial Funding", subtitle = null, description = "Desc Test", published = new DateOnly(2024,1,1), image = "newscover.jpg" }
        );
        
        modelBuilder.Entity<Project>().HasData(
            new Project { Id = Guid.NewGuid(), title = "Greener Egypt", subtitle = "Subtitle Test", description = "Description Test", category = "enviornment", UserId = Guid.Empty, currentfund = 500, totalfundrequired = 2000,images = new string[] {"1.jpg", "2.jpg" } },
            new Project { Id = Guid.NewGuid(), title = "My Super Awesome Health Machine", subtitle = "Subtitle Test", description = "Description Test", category = "health", currentfund = 500, totalfundrequired = 1000000, UserId = Guid.Empty, images = new string[] {"1.jpg", "2.jpg" } },
            new Project { Id = Guid.NewGuid(), title = "Electric Koshary Machine", subtitle = "Subtitle Test", description = "Description Test", category = "enviornment", currentfund = 500, totalfundrequired = 120000, UserId = Guid.Empty, images = new string[] {"1.jpg", "2.jpg" } },
            new Project { Id = Guid.NewGuid(), title = "Indie Egyptian Game", subtitle = "Subtitle Test", description = "Description Test", category = "enviornment", UserId = Guid.Empty, currentfund = 500, totalfundrequired = 60000, images = new string[] {"1.jpg", "2.jpg" } }
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