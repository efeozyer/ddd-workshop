using System;

namespace DDD.Workshop.IdentityAccess.Domain.Event
{
    public record UserPhoneNumberChanged
    {
        public Guid UserId { get; init; }

        public string PhoneNumber { get; init; }

        public UserPhoneNumberChanged(Guid userId, string phoneNumber)
        {
            UserId = userId;
            PhoneNumber = phoneNumber;
        }
    }
}
