using DDD.Workshop.SharedKernel.ValueObjects;

namespace DDD.Workshop.Customer.Domain.Events
{
    public record EmailAddressChanged
    {
        public EmailAddressChanged(CustomerId id, string emailAddress)
        {
            Id = id;
            EmailAddress = emailAddress;
        }

        public CustomerId Id { get; init; }
        public string EmailAddress { get; init; }

    }
}