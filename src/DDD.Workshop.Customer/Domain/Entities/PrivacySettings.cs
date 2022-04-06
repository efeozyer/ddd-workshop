using DDD.Workshop.Customer.Domain.Enums;
using DDD.Workshop.Customer.Domain.Events;
using DDD.Workshop.SharedKernel;
using DDD.Workshop.SharedKernel.ValueObjects;

namespace DDD.Workshop.Customer.Domain.Entities
{
    public class PrivacySettings : Aggregate<PrivacySettingsId>
    {
        public CustomerId CustomerId { get; set; }
        public bool IsMarketingNotificationEnabled { get; set; }
        public bool IsEmailNotificationEnabled { get; set; }
        public bool IsSmsNotificationEnabled { get; set; }

        public PrivacySettings()
        {
            
        }

        public PrivacySettings(bool isMarketingNotificationEnabled, bool isEmailNotificationEnabled, bool isSmsNotificationEnabled, CustomerId customerId)
        {
            IsMarketingNotificationEnabled = isMarketingNotificationEnabled;
            IsEmailNotificationEnabled = isEmailNotificationEnabled;
            IsSmsNotificationEnabled = isSmsNotificationEnabled;
            CustomerId = customerId;
        }

        public void UpdateMarketingNotification(bool isEnabled)
        {
            IsMarketingNotificationEnabled = isEnabled;

            Events.Add(new PermissionUpdated(Id,PermissionType.MarketingPermission, IsMarketingNotificationEnabled));
        }

        public void UpdateEmailNotification(bool isEnabled)
        {
            IsEmailNotificationEnabled = isEnabled;

            Events.Add(new PermissionUpdated(Id, PermissionType.EmailPermission, IsEmailNotificationEnabled));
        }

        public void UpdateSmsNotification(bool isEnabled)
        {
            IsSmsNotificationEnabled = isEnabled;

            Events.Add(new PermissionUpdated(Id, PermissionType.SmsPermission, IsSmsNotificationEnabled));
        }
    }
}
