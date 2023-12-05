using Logger.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Logger.Db
{
    public class LogContext : DbContext
    {

        public LogContext(DbContextOptions<LogContext> options) : base(options)
        {

        }

        public DbSet<LogDto> Logs { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDefaultSchema("Logs")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity<LogDto>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Date).IsRequired();
                e.Property(x => x.ErrorText).IsRequired();
            });
        }
    }
}
