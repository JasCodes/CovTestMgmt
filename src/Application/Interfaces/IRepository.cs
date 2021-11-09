using CovTestMgmt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CovTestMgmt.Application.Interfaces
{
    public interface IRepository
    {
        DbSet<User> Users { get; set; }
        DbSet<Center> Centers { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
