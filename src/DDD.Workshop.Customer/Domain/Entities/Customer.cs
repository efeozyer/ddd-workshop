using DDD.Workshop.Customer.Domain.Events;
using DDD.Workshop.SharedKernel;
using DDD.Workshop.SharedKernel.ValueObjects;

namespace DDD.Workshop.Customer.Domain.Entities
{
    public class Customer : Aggregate<CustomerId>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string EmailAddress { get; private set; }
        public string ProfileImageUrl { get; private set; }
        public UserId UserId { get; init; }

        public Customer()
        {
           
        }

        public Customer(string firstName, string lastName, string emailAddress, UserId userId, string profileImageUrl)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            UserId = userId;
            ProfileImageUrl = profileImageUrl;
        }

        public void ChangeEmailAddress(string emailAddress)
        {
            EmailAddress = emailAddress;

            Events.Add(new EmailAddressChanged(Id, EmailAddress));
        }

        public void UpdateProfileImage(string imageUrl)
        {
            ProfileImageUrl = imageUrl;

            Events.Add(new ProfileImageUpdated(Id, ProfileImageUrl));
        }
    }
}
