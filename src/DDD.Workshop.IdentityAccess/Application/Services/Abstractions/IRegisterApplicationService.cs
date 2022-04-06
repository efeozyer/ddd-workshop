using DDD.Workshop.IdentityAccess.Application.Models;
using DDD.Workshop.SharedKernel.ValueObjects;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.Workshop.IdentityAccess.Application.Services.Abstractions
{
    public interface IRegisterApplicationService
    {
        Task<UserId> RegisterUserAsync(CreateUserDto payload, CancellationToken cancellationToken = default);
    }
}
