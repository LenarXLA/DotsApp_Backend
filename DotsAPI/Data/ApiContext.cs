using DotsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotsAPI.Data;

public class ApiContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "DotsDb");
    }
    public DbSet<Dot> Dots { get; set; }
    public DbSet<Comment> Comments { get; set; }
}