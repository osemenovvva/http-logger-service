using Logger.Db;
using Logger.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Logger.Loggers
{
    public class PostgresqlDatabaseLogger : ILogger
    {
        private readonly IConfiguration Configuration;

        public PostgresqlDatabaseLogger(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ExecuteSaveLog(Guid id, DateTime date, string text)
        {
            var optionsBuilderRecognitionTasks = new DbContextOptionsBuilder<LogContext>();
            optionsBuilderRecognitionTasks.UseNpgsql(Configuration.GetConnectionString("Postgres"));
            
            var logContext = new LogContext(optionsBuilderRecognitionTasks.Options);
            logContext.Logs.Add(new LogDto()
            {
                Id = id,
                Date = date,
                ErrorText = text
            });

            logContext.SaveChanges();
        }
    }
}
