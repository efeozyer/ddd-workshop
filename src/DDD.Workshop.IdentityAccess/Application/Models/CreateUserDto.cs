using System;

namespace DDD.Workshop.IdentityAccess.Application.Models
{
    public record CreateUserDto
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string EmailAddress { get; init; }
        public string PhoneNumber { get; init; }
        public string Password { get; init; }
        public DateTime DateOfBirth { get; init; }

        public CreateUserDto(string firstName, string lastName, string emailAddress, string phoneNumber, string password, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            Password = password;
            DateOfBirth = dateOfBirth;
        }
    }

}
