using DDD.Workshop.IdentityAccess.Application.Models;
using DDD.Workshop.IdentityAccess.Domain.Entities;
using DDD.Workshop.SharedKernel.ValueObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.Workshop.IdentityAccess.ACL
{
    public interface IUserAdapter
    {
        Task<User> GetUserByIdAsync(UserId id, CancellationToken cancellationToken = default);

        Task<User> GetUserByEmailAddress(string emailAddress, CancellationToken cancellationToken = default);

        Task<UserId> CreateUser(CreateUserDto payload, CancellationToken cancellationToken = default);

        Task<bool> LockUser(string emailAddress, TimeSpan lockoutTime, CancellationToken cancellationToken = default);

        Task<string> LoginAsync(string emailAddress, string password, CancellationToken cancellationToken = default);
    }
}
