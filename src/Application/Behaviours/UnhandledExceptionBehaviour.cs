// using CovTestMgmt.Application.Common.Exceptions;
// using CovTestMgmt.Domain.Entities;
// using MediatR;
// using Microsoft.Extensions.Logging;
// using System;
// using System.Net;
// using System.Threading;
// using System.Threading.Tasks;

// namespace CovTestMgmt.Application.Common.Behaviours
// {
//     public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
//     // where TResponse : ApplicationException, new()
//     where TRequest : IRequest<TResponse>
//         where TResponse : IHttpResponse, new()
//     {
//         private readonly ILogger<TRequest> _logger;

//         public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
//         {
//             _logger = logger;
//         }

//         public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
//         {
//             try
//             {
//                 return await next();
//             }
//             // catch (ValidationException ex)
//             // {
//             //     _logger.LogError(ex, "Validation exception: {Message}", ex.Message);
//             //     // return 
//             //     foreach (var error in ex.Errors)
//             //     {
//             //         _logger.LogError(ex, "Validation exception: {key}: {value}", error.Key, error.Value);
//             //     }
//             //     foreach (var error in ex.Errors)
//             //     {
//             //         return new ApplicationResponse { StatusCode = System.Net.HttpStatusCode.BadRequest, ErrorMessage = error.Value[0] };

//             //     }
//             //     throw;
//             //     // return await next();
//             // }
//             catch (Exception ex)
//             {
//                 // var requestName = typeof(TRequest).ToString();

//                 // _logger.LogError(ex, "Covid Tests Management Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);
//                 _logger.LogError(ex, "Covid Tests Management Request: Unhandled Exception for Request");
//                 return new TResponse
//                 {
//                     Errors = { "test" },
//                     // Errors = { ex.InnerException.Message },
//                     StatusCode = HttpStatusCode.OK
//                     // StatusCode = HttpStatusCode.InternalServerError
//                 };
//                 // throw;
//             }
//             finally
//             {
//                 // return new TResponse
//                 // {
//                 //     Errors = { "test" },
//                 //     // Errors = { ex.InnerException.Message },
//                 //     StatusCode = HttpStatusCode.OK
//                 //     // StatusCode = HttpStatusCode.InternalServerError
//                 // }
//             }
//         }
//     }
// }
