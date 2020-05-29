using AutoMapper;
using DatabaseInfrastructure.Mapper;
using DatabaseInfrastructure.Repository;
using Domain.Persistence;
using Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrivateApi.Services;
using System;

namespace PrivateApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            if (Environment.IsDevelopment())
            {
                services.AddCors(options =>
                {
                    options.AddDefaultPolicy(policy =>
                    {
                        policy.AllowAnyHeader().AllowAnyMethod();
                        policy.SetIsOriginAllowed(origin => IsLocalhost(origin));
                    });
                });
            }

            services.AddControllers();

            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<EmployeeRepository>();
            services.AddScoped<IReadEmployee>(sp => sp.GetService<EmployeeRepository>());
            services.AddScoped<IWriteEmployee>(sp => sp.GetService<EmployeeRepository>());

            services.AddSingleton(new MapperConfiguration(cfg => cfg.AddProfile<EntityMapperProfile>()).CreateMapper());

            services.AddHealthChecks()
                .AddNpgSql(Configuration.GetConnectionString("UserMgmtDatabase"));

            services.AddDbContext<DatabaseInfrastructure.UserMgmtContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("UserMgmtDatabase")));

            services.AddHostedService<MigrateDatabaseService>();
        }

        private static bool IsLocalhost(string origin) =>
            string.Equals("localhost", new Uri(origin).Host, StringComparison.InvariantCultureIgnoreCase);

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/healthz");
            });
        }
    }
}
