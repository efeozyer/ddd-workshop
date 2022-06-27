using DDD.Workshop.SharedKernel.ValueObjects;
using System;

namespace DDD.Workshop.IdentityAccess.Domain.Events;

public record UserVerified
{
    public UserVerified(UserId id, DateTime verifiedOn)
    {
        Id = id;
        VerifiedOn = verifiedOn;
    }

    public UserId Id { get; }
    public DateTime VerifiedOn { get; }
}