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
    public static class GetHello
    {
        public class ResponseDTO
        {
            public string Message { get; init; }
        }

        public class Response : HttpResponse<ResponseDTO> { }

        public class Query : IRequest<Response>

        {
            [DefaultValue("World")]
            public string name { get; init; }
        }

        public class Handler : IRequestHandler<Query, Response>
        {
            public Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new Response { Data = new ResponseDTO { Message = $"Hello { request.name }" } });
            }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(o => o.name).NotEmpty().WithMessage("Name is required");
            }
        }
    }

}
