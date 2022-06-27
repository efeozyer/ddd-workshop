using DDD.Workshop.SharedKernel.ValueObjects;
using System.Threading.Tasks;

namespace DDD.Workshop.IdentityAccess.Application.Services
{
    public interface IRegisterService
    {
        Task RegisterAsync(string emailAddress, string phoneNumber, string password);

        Task VerifyAsync(UserId userId, string code);
    }
}