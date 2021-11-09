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
    public class LoginOrCreateNewUserResponse
    {
        public Guid UserId { get; init; }
    }

    public class LoginOrCreateNewUserRequest : IRequest<LoginOrCreateNewUserResponse>

    {
        public string Phone { get; init; }
        public string Email { get; init; }
    }

    public class LoginOrCreateNewUserHandler : IRequestHandler<LoginOrCreateNewUserRequest, LoginOrCreateNewUserResponse>
    {
        private readonly IRepository _repository;

        public LoginOrCreateNewUserHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<LoginOrCreateNewUserResponse> Handle(LoginOrCreateNewUserRequest request, CancellationToken cancellationToken)
        {
            var user = _repository.Users.Select(o => o).FirstOrDefault(o => o.Phone == request.Phone || o.Email == request.Email);
            // var users = _repository.Users.Where(o => o.Phone == request.Phone && o.Email == request.Email).ToList();
            // if (users.Any())
            // {
            //     return new Response
            //     {
            //         Data = new ResponseDTO
            //         {
            //             UserId = users.First().Id
            //         }
            //     };
            // }
            // else
            // {
            if (user != null) { return new LoginOrCreateNewUserResponse { UserId = user.Id }; }
            user = new User
            {
                Phone = request.Phone,
                Email = request.Email
            };
            _repository.Users.Add(user);
            var s = await _repository.SaveChangesAsync(cancellationToken);
            return new LoginOrCreateNewUserResponse { UserId = user.Id };

        }
    }

    public class LoginOrCreateNewUserValidator : AbstractValidator<LoginOrCreateNewUserRequest>
    {
        public LoginOrCreateNewUserValidator()
        {
            RuleFor(o => o)
            .Must(o => !String.IsNullOrWhiteSpace(o.Email) || !String.IsNullOrWhiteSpace(o.Phone))
            .WithMessage("Either name or phone is required.");

            RuleFor(o => o)
            .Must(o => String.IsNullOrWhiteSpace(o.Email) || String.IsNullOrWhiteSpace(o.Phone))
            .WithMessage("Can't use both email and phone.");
            // RuleFor(o => o)
            // .Must(o => String.IsNullOrWhiteSpace(o.Email) || String.IsNullOrWhiteSpace(o.Phone))
            // .WithMessage("Can't use both email and phone2.");

            RuleFor(o => o.Email).EmailAddress().WithMessage("Invalid email address.");
        }
    }


}
