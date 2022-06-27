using System;
using DDD.Workshop.SharedKernel;
using DDD.Workshop.SharedKernel.ValueObjects;
using DDD.Workshop.SharedKernel.Helpers;
using DDD.Workshop.IdentityAccess.Domain.Event;
using DDD.Workshop.IdentityAccess.Domain.Events;
using DDD.Workshop.SharedKernel.Constants;
using DDD.Workshop.SharedKernel.Enums;

namespace DDD.Workshop.IdentityAccess.Domain.Entities
{
    public class IdentityUser : Aggregate<UserId>
    {
        public string EmailAddress { get; private set; }

        public string PhoneNumber { get; private set; }

        public string PasswordHash { get; private set; }
        
        public IdentityUserStatus Status { get; private set; }
        
        public DateTime VerifiedOn { get; private set; }

        private IdentityUser()
        {
        }

        public IdentityUser(string emailAddress, string phoneNumber, string passwordHash)
        {
            Id = UserId.New();
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            PasswordHash = passwordHash;
            
            Events.Add(new IdentityUserCreated(Id, emailAddress));
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

        public void Verify()
        {
            Status = IdentityUserStatus.Verified;
            
            VerifiedOn = DateTimeHelper.Now();
            
            Events.Add(new UserVerified(Id, VerifiedOn));
        }
    }
}
