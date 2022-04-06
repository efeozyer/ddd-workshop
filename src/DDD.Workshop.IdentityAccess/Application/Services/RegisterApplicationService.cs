using DDD.Workshop.IdentityAccess.ACL;
using DDD.Workshop.IdentityAccess.Application.Models;
using DDD.Workshop.IdentityAccess.Application.Services.Abstractions;
using DDD.Workshop.SharedKernel.ValueObjects;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.Workshop.IdentityAccess.Application.Services
{
    public class RegisterApplicationService : IRegisterApplicationService
    {
        private readonly IUserAdapter _userAdapter;

        public RegisterApplicationService(IUserAdapter userAdapter)
        {
            _userAdapter = userAdapter;
        }


        public async Task<UserId> RegisterUserAsync(CreateUserDto payload, CancellationToken cancellationToken = default)
        {
            // TODO needs email
            return await _userAdapter.CreateUser(payload, cancellationToken);
        }
    }
}
