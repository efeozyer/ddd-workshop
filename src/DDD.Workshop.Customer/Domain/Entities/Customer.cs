using DDD.Workshop.Customer.Domain.Events;
using DDD.Workshop.SharedKernel;
using DDD.Workshop.SharedKernel.ValueObjects;

namespace DDD.Workshop.Customer.Domain.Entities
{
    public class Customer : Aggregate<CustomerId>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string ProfileImageUrl { get; private set; }
        public UserId UserId { get; init; }

        private Customer()
        {
           
        }

        public Customer(string firstName, string lastName, UserId userId, string profileImageUrl)
        {
            FirstName = firstName;
            LastName = lastName;
            UserId = userId;
            ProfileImageUrl = profileImageUrl;
        }

        public void UpdateProfileImage(string imageUrl)
        {
            ProfileImageUrl = imageUrl;

            Events.Add(new ProfileImageUpdated(Id, ProfileImageUrl));
        }
    }
}
