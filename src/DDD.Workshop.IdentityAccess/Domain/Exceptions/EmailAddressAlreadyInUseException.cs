using DDD.Workshop.Platform.Modeling;

namespace DDD.Workshop.IdentityAccess.Domain.Exceptions;

public class EmailAddressAlreadyInUseException : DomainException
{
    public override string ResourceKey => "EmailAddressAlreadyInUse";
}