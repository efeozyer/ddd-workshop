using DDD.Workshop.Platform.Modeling;

namespace DDD.Workshop.IdentityAccess.Domain.Exceptions;

public class IdentityUserAlreadyVerifiedException : DomainException
{
    public override string ResourceKey => "IdentityUserAlreadyVerified";
}