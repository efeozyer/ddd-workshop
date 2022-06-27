using DDD.Workshop.SharedKernel.ValueObjects;

namespace DDD.Workshop.IdentityAccess.Domain.Events;

public record IdentityUserCreated
{
    public UserId Id { get; }
    public string EmailAddress { get; }

    public IdentityUserCreated(UserId id, string emailAddress)
    {
        Id = id;
        EmailAddress = emailAddress;
    }
}