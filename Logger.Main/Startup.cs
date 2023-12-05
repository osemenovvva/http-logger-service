using Google.Api.Ads.Common.Lib;
using Logger.Db;
using Logger.Loggers;
using Microsoft.EntityFrameworkCore;

namespace Logger.Main
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("Postgres");
            services.AddDbContext<LogContext>(x => x.UseNpgsql(connectionString));

            // Add services to the container.
            services.AddRazorPages();
            services.AddControllers();
            services.AddSingleton<LogMessageQueue>();
            services.AddHostedService<LogWorker>();
            services.AddSingleton<LogService>();
            services.AddSingleton<TxtFileLogger>();
            services.AddSingleton<JsonFileLogger>();
            services.AddSingleton<XmlFileLogger>();
            services.AddSingleton<PostgresqlDatabaseLogger>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(x => x.MapRazorPages());
            app.UseEndpoints(x => x.MapControllers());
        }

    }
}
