using DDD.Workshop.IdentityAccess.ACL.AspNetIdentity.Models;
using DDD.Workshop.IdentityAccess.ACL.Exceptions;
using DDD.Workshop.IdentityAccess.Application.Models;
using DDD.Workshop.IdentityAccess.Domain.Entities;
using DDD.Workshop.SharedKernel.Constants;
using DDD.Workshop.SharedKernel.ValueObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.Workshop.IdentityAccess.ACL.AspNetIdentity
{
    public class UserAdapter : IUserAdapter
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserAdapter(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> LoginAsync(string emailAddress, string password, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                throw new OperationCanceledException();
            }

            var user = await _userManager.FindByEmailAsync(emailAddress);                        

            var signInResult =  await _signInManager.PasswordSignInAsync(user, password,false,true);

            if (!signInResult.Succeeded)
            {
                throw new InvalidOperationException(ErrorConstants.INVALID_CREDENTIALS);
            }

            // TODO Generate JWT
            return string.Empty;
        }

        public async Task<User> GetUserByIdAsync(UserId id, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                throw new OperationCanceledException();
            }

            var user = await _userManager.FindByIdAsync(id.ToString());

            return MapUser(user);
        }

        public async Task<User> GetUserByEmailAddress(string emailAddress, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                throw new OperationCanceledException();
            }

            var user = await _userManager.FindByEmailAsync(emailAddress);

            return MapUser(user);
        }

        public async Task<UserId> CreateUser(CreateUserDto payload, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                throw new OperationCanceledException();
            }

            var user = new ApplicationUser(payload.FirstName, payload.LastName, payload.EmailAddress, payload.PhoneNumber, payload.DateOfBirth);

            var identityResult = await _userManager.CreateAsync(user, payload.Password);

            if (!identityResult.Succeeded)
            {
                throw new CreateUserFailedException(ErrorConstants.CREATE_USER_FAILED, identityResult.Errors.Select(e => e.Description));
            }

            return new UserId(user.Id);
        }

        public async Task<bool> LockUser(string emailAddress, TimeSpan lockoutTime, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                throw new OperationCanceledException();
            }

            var user = await _userManager.FindByEmailAsync(emailAddress);

            user.LockoutEnabled = true;
            user.LockoutEnd = DateTime.UtcNow.Add(lockoutTime);

            return user.LockoutEnabled;
        }

        private static User MapUser(ApplicationUser user)
        {
            if (user == null)
            {
                throw new InvalidOperationException(ErrorConstants.USER_NOT_FOUND);
            }

            return new User(user.FirstName, user.LastName, user.Email, user.PhoneNumber, user.DateOfBirth);
        }
    }
}
