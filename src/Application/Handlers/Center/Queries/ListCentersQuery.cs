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
using Microsoft.EntityFrameworkCore;

namespace CovTestMgmt.Application.Handlers
{
    public class ListCentersResponse
    {
        // public Guid UserId { get; init; }
        public List<Center> Centers { get; init; }
    }

    public class ListCentersQuery : IRequest<ListCentersResponse>

    {
        // public string Phone { get; init; }
        // public string Email { get; init; }
    }

    public class ListCentersHandler : IRequestHandler<ListCentersQuery, ListCentersResponse>
    {
        private readonly IRepository _repository;

        public ListCentersHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ListCentersResponse> Handle(ListCentersQuery request, CancellationToken cancellationToken)
        {
            var centers = await _repository.Centers.ToListAsync();
            return new ListCentersResponse { Centers = centers }; ;
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
