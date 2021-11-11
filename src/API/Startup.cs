using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovTestMgmt.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using CovTestMgmt.API;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using CovTestMgmt.Infrastructure;
using CovTestMgmt.WebUI.Filters;
using FluentValidation.AspNetCore;
using CovTestMgmt.Application.Interfaces;
using CovTestMgmt.API.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;

namespace API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddControllers(options =>
                            options.Filters.Add<ApiExceptionFilterAttribute>())
                                .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

            services.AddApiVersioning(setup =>
            {
                setup.DefaultApiVersion = new ApiVersion(1, 0);
                setup.AssumeDefaultVersionWhenUnspecified = true;
                setup.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
                setup.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddSwaggerGen(options =>
            {
                // options.UseAllOfForInheritance();
                options.OperationFilter<DefaultValuesFilter>();
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.Last());
                options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    Name = "USER-ID",
                    In = ParameterLocation.Header,
                    // Name = "UserId",
                    Description = "Provide UserId",
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "ApiKey" }
                        },
                        new string[] { }
                    }
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
            services.ConfigureOptions<ConfigureSwaggerOptions>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    options.RoutePrefix = string.Empty;
                }
            });
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
