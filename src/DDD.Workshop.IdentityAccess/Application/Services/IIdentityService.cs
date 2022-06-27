using DDD.Workshop.SharedKernel.ValueObjects;
using System.Threading.Tasks;

namespace DDD.Workshop.IdentityAccess.Application.Services
{
    public interface IIdentityService
    {
        Task ChangePassword(UserId userId, string oldPassword, string newPassword);
        
        Task ForgotPassword(UserId userId, string emailAddress);
        
        Task ResetPassword(UserId userId, string code, string password);
        
        Task ChangeEmailAddress(UserId userId, string emailAddress);
        
        Task ChangePhoneNumber(UserId userId, string phoneNumber);
    }
}