using Logger;
using Logger.Loggers;
using Logger.Main;
using Microsoft.AspNetCore;

namespace Logger.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hosting, config) => { ConfigureAppConfiguration(hosting, config, args); })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void ConfigureAppConfiguration(HostBuilderContext hostingContext, IConfigurationBuilder config, string[] args)
        {
            var env = hostingContext.HostingEnvironment;

            config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                  .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                  .AddEnvironmentVariables();

            if (env.IsDevelopment())
                config.AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true);
        }
    }

}