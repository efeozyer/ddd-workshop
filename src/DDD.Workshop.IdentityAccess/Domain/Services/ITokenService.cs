using DDD.Workshop.SharedKernel.ValueObjects;
using System.Threading.Tasks;

namespace DDD.Workshop.IdentityAccess.Domain.Services
{
    public interface ITokenService
    {
        Task<string> GenerateAsync(UserId userId, string emailAddress, string phoneNumber);
    }
}