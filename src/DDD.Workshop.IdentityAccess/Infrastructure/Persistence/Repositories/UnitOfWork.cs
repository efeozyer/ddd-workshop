using DDD.Workshop.IdentityAccess.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.Workshop.IdentityAccess.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly IdentityDbContext _identityDbContext;

    public IIdentityUserRepository IdentityUsers { get; }

    public UnitOfWork(IdentityDbContext identityDbContext)
    {
        _identityDbContext = identityDbContext;
        
        IdentityUsers = new IdentityUserRepository(identityDbContext);
    }
    
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _identityDbContext.SaveChangesAsync(cancellationToken);
    }
}