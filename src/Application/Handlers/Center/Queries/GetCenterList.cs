using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CovTestMgmt.Application.Interfaces;
using CovTestMgmt.Domain.Entities;
using FluentValidation;
using MediatR;

namespace CovTestMgmt.Application.Handlers
{
    public class GetCentersListResponse
    {
        // public Guid UserId { get; init; }
        public List<Center> Centers { get; init; }
    }

    public class GetCentersListRequest : IRequest<GetCentersListResponse>

    {
        // public string Phone { get; init; }
        // public string Email { get; init; }
    }

    public class GetCentersListHandler : IRequestHandler<GetCentersListRequest, GetCentersListResponse>
    {
        private readonly IRepository _repository;

        public GetCentersListHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCentersListResponse> Handle(GetCentersListRequest request, CancellationToken cancellationToken)
        {
            var centers = _repository.Centers.ToList();
            return new GetCentersListResponse() { Centers = centers };
        }
    }

    // public class LoginOrCreateNewUserValidator : AbstractValidator<LoginOrCreateNewUserRequest>
    // {
    //     public LoginOrCreateNewUserValidator()
    //     {
    //         RuleFor(o => o)
    //         .Must(o => !String.IsNullOrWhiteSpace(o.Email) || !String.IsNullOrWhiteSpace(o.Phone))
    //         .WithMessage("Either name or phone is required.");

    //         RuleFor(o => o)
    //         .Must(o => String.IsNullOrWhiteSpace(o.Email) || String.IsNullOrWhiteSpace(o.Phone))
    //         .WithMessage("Can't use both email and phone.");
    //         // RuleFor(o => o)
    //         // .Must(o => String.IsNullOrWhiteSpace(o.Email) || String.IsNullOrWhiteSpace(o.Phone))
    //         // .WithMessage("Can't use both email and phone2.");

    //         RuleFor(o => o.Email).EmailAddress().WithMessage("Invalid email address.");
    //     }
    // }


}
