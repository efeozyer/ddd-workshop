using DDD.Workshop.SharedKernel.ValueObjects;

namespace DDD.Workshop.IdentityAccess.Domain.Event
{
    public record UserPasswordChanged
    {
        public UserId UserId { get; init; }

        public UserPasswordChanged(UserId userId)
        {
            UserId = userId;
        }
    }
}
