using Microsoft.EntityFrameworkCore;
using PortfolioApi.Models;

namespace PortfolioApi.Data;

public class PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : DbContext(options)
{
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Blogpost> Blogposts => Set<Blogpost>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>(entity =>
        {
            entity.Property(project => project.Titel).HasMaxLength(150).IsRequired();
            entity.Property(project => project.Beschrijving).HasMaxLength(2000).IsRequired();
            entity.Property(project => project.Categorie).HasMaxLength(100).IsRequired();
            entity.Property(project => project.AfbeeldingUrl).HasMaxLength(500);
            entity.Property(project => project.AfbeeldingAlt).HasMaxLength(250);
        });

        modelBuilder.Entity<Blogpost>(entity =>
        {
            entity.Property(blogpost => blogpost.Titel).HasMaxLength(200).IsRequired();
            entity.Property(blogpost => blogpost.Inhoud).HasMaxLength(10000).IsRequired();
        });
    }
}
