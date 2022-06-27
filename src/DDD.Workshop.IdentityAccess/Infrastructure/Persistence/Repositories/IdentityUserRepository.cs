using DDD.Workshop.IdentityAccess.Domain.Entities;
using DDD.Workshop.IdentityAccess.Domain.Repositories;
using DDD.Workshop.Platform.Persistence;
using DDD.Workshop.SharedKernel.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.Workshop.IdentityAccess.Infrastructure.Persistence.Repositories
{
    public class IdentityUserRepository : IIdentityUserRepository
    {
        private readonly IdentityDbContext _context;

        public IdentityUserRepository(IdentityDbContext context)
        {
            _context = context;
        }
        
        public async Task AddAsync(IdentityUser identityUser, CancellationToken cancellationToken)
        {
            await _context.IdentityUsers.AddAsync(identityUser, cancellationToken); 
        }
        
        public async Task<IdentityUser> GetAsync(UserId userId, CancellationToken cancellationToken)
        {
            var identityUser = await _context.IdentityUsers.SingleOrDefaultAsync(i=> i.Id == userId, cancellationToken: cancellationToken);

            if (identityUser is null)
                throw new RecordNotFound<IdentityUser>(userId.Value);

            return identityUser;
        }

        public async Task<bool> IsExistsAsync(Expression<Func<IdentityUser, bool>> expression, CancellationToken cancellationToken)
        {
            return await _context.IdentityUsers.AnyAsync(expression, cancellationToken);
        }
    }
}