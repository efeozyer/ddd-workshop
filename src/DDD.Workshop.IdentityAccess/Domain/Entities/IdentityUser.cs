using System;
using DDD.Workshop.SharedKernel;
using DDD.Workshop.SharedKernel.ValueObjects;
using DDD.Workshop.SharedKernel.Helpers;
using DDD.Workshop.IdentityAccess.Domain.Event;
using DDD.Workshop.SharedKernel.Constants;

namespace DDD.Workshop.IdentityAccess.Domain.Entities
{
    public class IdentityUser : Aggregate<UserId>
    {
        public string EmailAddress { get; private set; }

        public string PhoneNumber { get; private set; }

        public string PasswordHash { get; private set; }

        private IdentityUser()
        {
        }

        public IdentityUser(string emailAddress, string phoneNumber, DateTime dateOfBirth, string passwordHash)
        {
            
            if (DateTimeHelper.CalculateAge(dateOfBirth) < RuleConstants.MIN_USER_AGE)
                throw new InvalidOperationException(ErrorConstants.INVALID_USER_AGE);
            
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            PasswordHash = passwordHash;
        }

        public void ChangeEmailAddress(string emailAddress)
        {
            EmailAddress = emailAddress;

            Events.Add(new UserEmailAddressChanged(Id));
        }

        public void ChangePhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;

            Events.Add(new UserPhoneNumberChanged(Id, phoneNumber));
        }
        
        public void ChangePassword(string passwordHash)
        {
            PasswordHash = passwordHash;

            Events.Add(new UserPasswordChanged(Id));
        }
    }
}
