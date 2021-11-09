using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CovTestMgmt.Domain.Entities;
using FluentValidation;
using MediatR;
using ValidationException = CovTestMgmt.Application.Exceptions.ValidationException;

namespace CovTestMgmt.Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Any())
                    throw new ValidationException(failures);
            }
            return await next();
        }
    }
    // public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    //     where TRequest : IRequest<TResponse>
    //     where TResponse : IHttpResponse, new()
    // {
    //     private readonly IEnumerable<IValidator<TRequest>> _validators;

    //     public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    //     {
    //         _validators = validators;
    //     }

    //     public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    //     {
    //         if (_validators.Any())
    //         {
    //             var context = new ValidationContext<TRequest>(request);

    //             var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
    //             var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

    //             if (failures.Any())
    //             {
    //                 return new TResponse
    //                 {
    //                     StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
    //                     Errors = failures.Select(f => f.ErrorMessage).ToList()
    //                     // Success = false,
    //                     // Message = "Validation error",
    //                     // Errors = failures
    //                 };
    //             }
    //             // throw new ValidationException(failures);
    //             // if (failures.Count != 0)
    //             //     throw new ValidationException(failures);
    //         }
    //         return await next();
    //     }
    // }

}