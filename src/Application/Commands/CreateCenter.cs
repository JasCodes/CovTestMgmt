using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CovTestMgmt.Application.Interfaces;
using CovTestMgmt.Domain.Entities;
using MediatR;

namespace CovTestMgmt.Application.Commands
{
    public static class CreateCenter
    {
        public class Query : IAuthRequest<Guid>
        {
            public String Name { get; init; }
        }

        public class Handler : IRequestHandler<Query, Guid>
        {
            private readonly IRepository _repository;

            public Handler(IRepository repository)
            {
                _repository = repository;
            }

            public async Task<Guid> Handle(Query request, CancellationToken cancellationToken)
            {
                var center = await _repository.Centers.AddAsync(new Center { Name = request.Name });
                await _repository.SaveChangesAsync(cancellationToken);
                return center.Entity.Id;
            }

        }

    }
}