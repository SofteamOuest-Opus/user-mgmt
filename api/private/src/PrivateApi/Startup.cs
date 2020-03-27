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

namespace PrivateApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
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
        }

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/healthz");
            });
        }
    }
}
