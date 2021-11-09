using CovTestMgmt.Application.Commands;
using CovTestMgmt.Application.Exceptions;
using CovTestMgmt.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CovTestMgmt.Application.Behaviours
{
    public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
            where TRequest : IAuthRequest<TResponse>

    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IRepository _repository;
        private readonly IConfiguration _configuration;


        public AuthorizationBehaviour(ICurrentUserService currentUserService, IRepository repository, IConfiguration configuration)
        {
            _currentUserService = currentUserService;
            _repository = repository;
            _configuration = configuration;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {

            // Must be authenticated user
            if (_currentUserService.UserId == null)
            {
                throw new UnauthorizedAccessException();
            }

            // Verify user exists in database            
            var user = _repository.Users.Select(o => o).FirstOrDefault(o => o.Id == _currentUserService.UserId);
            if (user == null)
            {
                throw new ForbiddenAccessException();
            }

            return await next();

        }
    }
}
