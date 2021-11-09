using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovTestMgmt.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace CovTestMgmt.API.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public Guid UserId
        {
            get
            {
                var userId = _configuration["Auth:UserIdOverride"] ?? _httpContextAccessor.HttpContext?.Request?.Headers["USER-ID"];
                try
                {
                    return Guid.Parse(userId);
                }
                catch
                {
                    return Guid.Empty;
                }
            }
        }

        // Guid ICurrentUserService.UserId => throw new NotImplementedException();
    }
}