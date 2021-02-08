using BenFatto.Data.Mapping;
using BenFatto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class LogContext : DbContext
{
    public DbSet<Log> Logs { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=benfattoteste.cdk1xjvrtgjd.us-east-2.rds.amazonaws.com;Database=postgres;Username=postgres;Password=1q2w3e4r");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Log>(new LogMap().Configure);
    }
}
