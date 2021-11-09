using System;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CovTestMgmt.API
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            this.provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            for (int i = provider.ApiVersionDescriptions.Count - 1; i >= 0; i--)
            {
                var description = provider.ApiVersionDescriptions[i];
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
            // add swagger document for every API version discovered
            // foreach (var description in provider.ApiVersionDescriptions)
            // {
            //     options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            // }
        }

        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        private OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "Covid Test Management",
                Version = description.ApiVersion.ToString()
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
}