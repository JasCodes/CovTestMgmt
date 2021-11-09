using System;

namespace CovTestMgmt.Application.Interfaces
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }
    }
}