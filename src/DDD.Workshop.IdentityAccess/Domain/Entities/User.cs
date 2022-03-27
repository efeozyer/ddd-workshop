using System;
using DDD.Workshop.SharedKernel;
using DDD.Workshop.SharedKernel.ValueObjects;
using DDD.Workshop.SharedKernel.Helpers;
using DDD.Workshop.IdentityAccess.Domain.Event;
using DDD.Workshop.SharedKernel.Constants;

namespace DDD.Workshop.IdentityAccess.Domain.Entities
{
    public class User : Aggregate<UserId>
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public string PasswordHash { get; private set; }

        public DateTime? LockedOutDateUtc { get; private set; }

        public string EmailAddress { get; private set; }

        public string PhoneNumber { get; private set; }

        public User()
        {

        }

        public User(string firstName, string lastName, string emailAddress, string phoneNumber, DateTime dateOfBirth, string passwordHash)
        {
            
            if (DateTimeHelper.CalculateAge(dateOfBirth) < RuleConstants.MIN_USER_AGE)
                throw new InvalidOperationException(ErrorConstants.INVALID_USER_AGE);

            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            PasswordHash = passwordHash;
        }

        public void Lockout(UserId operatorUserId, string reason, TimeSpan value)
        {
            LockedOutDateUtc = DateTime.UtcNow.Add(value);

            Events.Add(new UserLockedOut(Id, operatorUserId, reason)); 
        }

        public void ChangePassword(string passwordHash)
        {
            PasswordHash = passwordHash;

            Events.Add(new UserPasswordChanged(Id));
        }

        public void ChangeEmailAddress(string emailAddress)
        {
            EmailAddress = emailAddress;

            Events.Add(new UserEmailAddressChanged(Id));
        }

        public void ChangePhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;

            Events.Add(new UserPhoneNumberChanged(Id.Value, phoneNumber));
        }
    }
}
