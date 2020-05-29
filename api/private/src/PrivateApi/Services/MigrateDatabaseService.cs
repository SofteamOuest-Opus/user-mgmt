using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PrivateApi.Services
{
    internal class MigrateDatabaseService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<MigrateDatabaseService> _logger;

        public MigrateDatabaseService(IServiceProvider serviceProvider, ILogger<MigrateDatabaseService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var serviceScope = _serviceProvider.CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<DatabaseInfrastructure.UserMgmtContext>();

            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Could not migrate database");
            }

            return Task.CompletedTask;
        }
    }
}