using System;

namespace AddressBook.Api.Infrastructure.Exceptions
{
    public class ContactException : Exception
    {
        public ContactException()
        {
        }

        public ContactException(string message) 
            : base(message)
        {
        }

        public ContactException(string message, Exception exception) 
            : base(message, exception)
        {
        }
    }
}
