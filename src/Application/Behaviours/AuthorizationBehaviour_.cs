// using CovTestMgmt.Application.Exceptions;
// using CovTestMgmt.Application.Interfaces;
// using CovTestMgmt.Domain.Entities;
// using MediatR;
// using System;
// using System.Linq;
// using System.Net;
// using System.Reflection;
// using System.Threading;
// using System.Threading.Tasks;

// namespace CovTestMgmt.Application.Common.Behaviours
// {
//     public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
//         where TRequest : IRequest<TResponse>
//         where TResponse : IHttpResponse, new()
//     {
//         private readonly ICurrentUserService _currentUserService;

//         public AuthorizationBehaviour(
//             ICurrentUserService currentUserService)
//         {
//             _currentUserService = currentUserService;
//         }

//         public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
//         {
//             if (String.IsNullOrWhiteSpace(_currentUserService.UserId))
//             {
//                 return new TResponse
//                 {
//                     StatusCode = HttpStatusCode.Unauthorized,
//                     Errors = { "Unauthorized" }
//                 };
//             }
//             return await next();
//         }

//     }
// }