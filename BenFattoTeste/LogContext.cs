using System;

public class LogContext : DbContext
{
    public DbSet<Log> Logs { get; set; }

    public LogContext(DbContextOptions<LogContext> options) :
        base(options)
    {
    }
}
