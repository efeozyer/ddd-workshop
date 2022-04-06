using DDD.Workshop.Customer.Domain.Entities;
using DDD.Workshop.Customer.Domain.Enums;
using DDD.Workshop.SharedKernel.ValueObjects;

namespace DDD.Workshop.Customer.Domain.Events
{
    public record PermissionUpdated
    {
        public PermissionUpdated(PrivacySettingsId id, PermissionType permissionType, bool value)
        {
            Id = id;
            PermissionType = permissionType;
            Value = value;
        }

        public PrivacySettingsId Id { get; init; }
        public PermissionType PermissionType { get; init; }
        public bool Value { get; init; }
    }
}