using System;
using System.Net;

namespace DDD.Workshop.Platform.Modeling;

public abstract class DomainException : Exception
{
    public abstract string ResourceKey { get; }

    public virtual HttpStatusCode StatusCode { get; } = HttpStatusCode.InternalServerError;
}