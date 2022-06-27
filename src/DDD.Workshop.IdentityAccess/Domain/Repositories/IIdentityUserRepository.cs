using DDD.Workshop.IdentityAccess.Domain.Entities;
using DDD.Workshop.SharedKernel.ValueObjects;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.Workshop.IdentityAccess.Domain.Repositories
{
    public interface IIdentityUserRepository
    {
        Task AddAsync(IdentityUser identityUser, CancellationToken cancellationToken);
        Task<IdentityUser> GetAsync(UserId userId, CancellationToken cancellationToken);
        Task<bool> IsExistsAsync(Expression<Func<IdentityUser, bool>> expression, CancellationToken cancellationToken);
    }
}