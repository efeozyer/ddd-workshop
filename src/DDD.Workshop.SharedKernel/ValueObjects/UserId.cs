namespace DDD.Workshop.SharedKernel.ValueObjects
{
    [StronglyTypedId(jsonConverter: StronglyTypedIdJsonConverter.SystemTextJson, backingType: StronglyTypedIdBackingType.String)]
    public partial struct UserId { }
}
