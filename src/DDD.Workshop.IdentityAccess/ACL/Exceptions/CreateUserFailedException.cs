using System;
using System.Collections.Generic;

namespace DDD.Workshop.IdentityAccess.ACL.Exceptions
{
    public class CreateUserFailedException : InvalidOperationException
    {
        public IEnumerable<string> Errors { get; }

        public CreateUserFailedException(string userFailed, IEnumerable<string> errors) : base(userFailed)
        {
            Errors = errors;
        }
    }
}