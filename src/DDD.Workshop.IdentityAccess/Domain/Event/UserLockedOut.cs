using DDD.Workshop.SharedKernel.ValueObjects;

namespace DDD.Workshop.IdentityAccess.Domain.Event
{
    public record UserLockedOut
    {
        public UserId UserId { get; init; }
        public UserId OperatorUserId { get; init; }
        public string Reason { get; init; }

        public UserLockedOut(UserId userId, UserId operatorUserId, string reason)
        {
            UserId = userId;
            OperatorUserId = operatorUserId;
            Reason = reason;
        }
    }
}
