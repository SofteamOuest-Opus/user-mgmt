using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace PrivateApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CreateWebHostBuilder(args)
                    .Build()
                    .MigrateDatabase()
                    .Run();
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
                .UseNLog();
    }

    internal static class Extensions
    {
        internal static IWebHost MigrateDatabase(this IWebHost host)
        {
            using (var serviceScope = host.Services.CreateScope())
            using (var context = serviceScope.ServiceProvider.GetService<DatabaseInfrastructure.UserMgmtContext>())
            {
                context.Database.Migrate();
            }
            return host;
        }

    }
}
