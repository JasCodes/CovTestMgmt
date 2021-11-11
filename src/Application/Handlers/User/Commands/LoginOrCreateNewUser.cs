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
    public class LoginOrCreateNewUserCommandResponse
    {
        public Guid UserId { get; init; }
    }

    public class LoginOrCreateNewUserCommand : IRequest<LoginOrCreateNewUserCommandResponse>

    {
        public string Phone { get; init; }
        public string Email { get; init; }
    }

    public class LoginOrCreateNewUserCommandHandler : IRequestHandler<LoginOrCreateNewUserCommand, LoginOrCreateNewUserCommandResponse>
    {
        private readonly IRepository _repository;

        public LoginOrCreateNewUserCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<LoginOrCreateNewUserCommandResponse> Handle(LoginOrCreateNewUserCommand request, CancellationToken cancellationToken)
        {
            var user = _repository.Users.Select(x => x).FirstOrDefault(o => o.Phone == request.Phone || o.Email == request.Email);

            if (user != null) { return new LoginOrCreateNewUserCommandResponse { UserId = user.Id }; }
            user = new User
            {
                Phone = request.Phone,
                Email = request.Email
            };
            _repository.Users.Add(user);
            await _repository.SaveChangesAsync(cancellationToken);
            return new LoginOrCreateNewUserCommandResponse { UserId = user.Id };

        }
    }

    public class LoginOrCreateNewUserCommandValidator : AbstractValidator<LoginOrCreateNewUserCommand>
    {
        public LoginOrCreateNewUserCommandValidator()
        {
            RuleFor(o => o)
            .Must(o => !String.IsNullOrWhiteSpace(o.Email) || !String.IsNullOrWhiteSpace(o.Phone))
            .WithMessage("Either name or phone is required.");

            RuleFor(o => o)
            .Must(o => String.IsNullOrWhiteSpace(o.Email) || String.IsNullOrWhiteSpace(o.Phone))
            .WithMessage("Can't use both email and phone.");

            RuleFor(o => o.Email).EmailAddress().WithMessage("Invalid email address.");
        }
    }


}
