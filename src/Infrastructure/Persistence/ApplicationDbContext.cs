using CovTestMgmt.Application.Interfaces;
using CovTestMgmt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CovTestMgmt.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IRepository
    {
        // private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;
        // private readonly IDomainEventService _domainEventService;

        public ApplicationDbContext(
            DbContextOptions options,
            // IOptions<OperationalStoreOptions> operationalStoreOptions,
            // ICurrentUserService currentUserService,
            // IDomainEventService domainEventService,
            IDateTime dateTime)
        : base(options)
        // : base(options, operationalStoreOptions)
        {
            // _currentUserService = currentUserService;
            // _domainEventService = domainEventService;
            _dateTime = dateTime;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Center> Centers { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

    }
}
