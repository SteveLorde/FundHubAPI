using FundHubAPI.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace FundHubAPI.Data;

public class DataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=EShop;Username=postgres;Password=World2050");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<News>().HasData(
            new News { NewsId = Guid.NewGuid(), title = "News 1", subtitle = null, description = "Desc Test", published = new DateOnly(2024,1,1), image = "newscover.jpg"},
            new News { NewsId = Guid.NewGuid(), title = "News 2", subtitle = null, description = "Desc Test", published = new DateOnly(2024,1,1), image = "newscover.jpg" },
            new News { NewsId = Guid.NewGuid(), title = "News 3", subtitle = null, description = "Desc Test", published = new DateOnly(2024,1,1), image = "newscover.jpg" }
        );
        
    }

    public DbSet<FundProject> FundProjects { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<FundLogs> PurchaseLogs { get; set; }
}