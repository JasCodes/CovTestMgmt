using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CovTestMgmt.Application.Interfaces;
using CovTestMgmt.Domain.Entities;
using MediatR;

namespace CovTestMgmt.Application.Handlers
{
    public class CreateCenterResponse
    {
        public Center Center { get; set; }
    }
    public class CreateCenterCommand : IAuthRequest<CreateCenterResponse>
    {
        public String Name { get; init; }
    }

    public class Handler : IRequestHandler<CreateCenterCommand, CreateCenterResponse>
    {
        private readonly IRepository _repository;

        public Handler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateCenterResponse> Handle(CreateCenterCommand request, CancellationToken cancellationToken)
        {
            var center = await _repository.Centers.AddAsync(new Center { Name = request.Name });
            await _repository.SaveChangesAsync(cancellationToken);
            return new CreateCenterResponse { Center = center.Entity };
        }
    }

}
