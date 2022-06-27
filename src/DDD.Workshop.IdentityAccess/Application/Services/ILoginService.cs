using DDD.Workshop.SharedKernel.ValueObjects;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.Workshop.IdentityAccess.Application.Services
{
    public interface ILoginService
    {
        Task TwoFactorAuthenticateAsync(UserId userId, string code, CancellationToken cancellationToken);
        
        Task LoginAsync(string emailAddress, string password, CancellationToken cancellationToken);
    }
}