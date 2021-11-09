using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CovTestMgmt.Application.Interfaces
{
    public interface IAuthRequest<T> : IRequest<T> { }
}