using DDD.Workshop.SharedKernel.ValueObjects;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.Workshop.IdentityAccess.Application.Services
{
    public interface IRegisterService
    {
        Task RegisterAsync(string emailAddress, string phoneNumber, string password, CancellationToken cancellationToken);

        Task VerifyAsync(UserId userId, string code, CancellationToken cancellationToken);
    }
}