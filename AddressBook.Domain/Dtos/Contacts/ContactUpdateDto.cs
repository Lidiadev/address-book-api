using System;
using System.Collections.Generic;

namespace AddressBook.Domain.Dtos.Contacts
{
    public class ContactUpdateDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ICollection<string> TelephoneNumbers { get; set; }
    }
}
