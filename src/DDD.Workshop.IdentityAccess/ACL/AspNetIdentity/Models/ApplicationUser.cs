using Microsoft.AspNetCore.Identity;
using System;

namespace DDD.Workshop.IdentityAccess.ACL.AspNetIdentity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser(string firstName, string lastName, string emailAddress, string phoneNumber, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
        public string EmailAddress { get; }
        public string PhoneNumber { get; }

        public DateTime DateOfBirth { get; private set; }

    }
}
