using DDD.Workshop.IdentityAccess.Domain.Entities;
using DDD.Workshop.IdentityAccess.Domain.Exceptions;
using DDD.Workshop.IdentityAccess.Domain.Repositories;
using DDD.Workshop.SharedKernel.Enums;
using DDD.Workshop.SharedKernel.ValueObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.Workshop.IdentityAccess.Application.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task RegisterAsync(string emailAddress, string phoneNumber, string password,
            CancellationToken cancellationToken)
        {
            var identityUser = new IdentityUser(emailAddress, phoneNumber, password);

            var isEmailAddressInUse =
                await _unitOfWork.IdentityUsers.IsExistsAsync(x => x.EmailAddress.ToLower() == emailAddress.ToLower(), cancellationToken);

            if (isEmailAddressInUse)
                throw new EmailAddressAlreadyInUseException();

            var isPhoneNumberInUse =
                await _unitOfWork.IdentityUsers.IsExistsAsync(x => x.PhoneNumber.ToLower() == phoneNumber.ToLower(), cancellationToken);

            if (isPhoneNumberInUse)
                throw new PhoneNumberAlreadyInUseException();

            await _unitOfWork.IdentityUsers.AddAsync(identityUser, cancellationToken);
            
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task VerifyAsync(UserId userId, string code, CancellationToken cancellationToken)
        {
            var identityUser = await _unitOfWork.IdentityUsers.GetAsync(userId, cancellationToken);

            if (identityUser.Status == IdentityUserStatus.Verified)
                throw new IdentityUserAlreadyVerifiedException();

            if (true) // TODO check if is code valid
                identityUser.Verify();

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}