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

            // if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            // {
            // services.AddDbContext<AppDbContext>(options =>
            //     options.UseInMemoryDatabase("CovTestMgmtDb"));
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite("Data Source=./../Infrastructure/database.sqlite"));
            // }
            // else
            // {
            //     services.AddDbContext<AppDbContext>(options =>
            //         options.UseSqlServer(
            //             configuration.GetConnectionString("DefaultConnection"),
            //             b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
            // }

            services.AddScoped<IRepository>(provider => provider.GetService<ApplicationDbContext>());


            services.AddTransient<IDateTime, DateTimeService>();
            // services.AddTransient<IIdentityService, IdentityService>();
            // services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();


            return services;
        }
    }
}