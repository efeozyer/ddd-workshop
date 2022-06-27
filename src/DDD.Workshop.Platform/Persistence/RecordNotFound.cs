using System;

namespace DDD.Workshop.Platform.Persistence;

public class RecordNotFound<T> : Exception
{
    public RecordNotFound(Guid id) : base($"{nameof(T)} is not found with id: {id}")
    {
    }
}