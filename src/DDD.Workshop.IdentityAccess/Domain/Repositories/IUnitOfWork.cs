using System.Threading;
using System.Threading.Tasks;

namespace DDD.Workshop.IdentityAccess.Domain.Repositories;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
    IIdentityUserRepository IdentityUsers { get; }
}