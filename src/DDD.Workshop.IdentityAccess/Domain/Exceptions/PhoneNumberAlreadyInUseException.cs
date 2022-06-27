using DDD.Workshop.Platform.Modeling;

namespace DDD.Workshop.IdentityAccess.Domain.Exceptions;

public class PhoneNumberAlreadyInUseException  : DomainException
{
    public override string ResourceKey => "PhoneNumberAlreadyInUse";
}