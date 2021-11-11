using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CovTestMgmt.Domain.Entities;
using FluentValidation;
using MediatR;

namespace CovTestMgmt.Application.Handlers
{
    public class GetHelloQueryResponse
    {
        public string Message { get; init; }
    }

    public class GetHelloQuery : IRequest<GetHelloQueryResponse>

    {
        [DefaultValue("World")]
        public string Name { get; init; }
    }

    public class GetHelloQueryHandler : IRequestHandler<GetHelloQuery, GetHelloQueryResponse>
    {
        public async Task<GetHelloQueryResponse> Handle(GetHelloQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new GetHelloQueryResponse { Message = $"Hello {request.Name}" });
        }
    }

    public class GetHelloQueryValidator : AbstractValidator<GetHelloQuery>
    {
        public GetHelloQueryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }

}
