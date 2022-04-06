using DDD.Workshop.SharedKernel.ValueObjects;

namespace DDD.Workshop.Customer.Domain.Events
{
    public record ProfileImageUpdated
    {
        public CustomerId Id { get; }
        public string ProfileImageUrl { get; }

        public ProfileImageUpdated(CustomerId id, string profileImageUrl)
        {
            Id = id;
            ProfileImageUrl = profileImageUrl;
        }
    }
}