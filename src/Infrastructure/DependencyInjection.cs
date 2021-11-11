using CovTestMgmt.Application.Interfaces;
using CovTestMgmt.Infrastructure.Persistence;
using CovTestMgmt.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CovTestMgmt.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // string ConnectionString = configuration.GetValue<string>("ConnectionString");

            // if (string.IsNullOrWhiteSpace(ConnectionString))
            // {
            //     services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlite("Data Source=database.sqlite"));
            // }
            // else
            // {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                )
            );
            // }
            // services.AddDbContext<AppDbContext>(options =>
            //     options.UseInMemoryDatabase("CovTestMgmtDb"));

            services.AddScoped<IRepository>(provider => provider.GetService<ApplicationDbContext>());


            services.AddTransient<IDateTime, DateTimeService>();
            // services.AddTransient<IIdentityService, IdentityService>();
            // services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();


            return services;
        }
    }
}