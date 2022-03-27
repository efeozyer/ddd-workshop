using DDD.Workshop.SharedKernel.ValueObjects;

namespace DDD.Workshop.IdentityAccess.Domain.Event
{
    public record UserEmailAddressChanged
    {
        public UserId Id { get; init; }

        public UserEmailAddressChanged(UserId id)
        {
            Id = id;
        }
    }
}
