using Microsoft.EntityFrameworkCore;
using marketplace.Data.Entities;
using marketplace.Auth.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace marketplace.Data;

public class MarketplaceDbContext : IdentityDbContext<MarketplaceRestUser>
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Ad> Ads { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=MarketplaceDbv4");
    }
}
