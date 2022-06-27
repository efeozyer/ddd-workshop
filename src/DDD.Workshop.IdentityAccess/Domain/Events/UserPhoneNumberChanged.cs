using DDD.Workshop.SharedKernel.ValueObjects;
using System;

namespace DDD.Workshop.IdentityAccess.Domain.Event
{
    public record UserPhoneNumberChanged
    {
        public UserId UserId { get; init; }

        public string PhoneNumber { get; init; }

        public UserPhoneNumberChanged(UserId userId, string phoneNumber)
        {
            UserId = userId;
            PhoneNumber = phoneNumber;
        }
    }
}
