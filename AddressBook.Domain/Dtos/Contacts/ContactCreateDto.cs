using System;
using System.Collections.Generic;

namespace AddressBook.Domain.Dtos.Contacts
{
    public class ContactCreateDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        public IReadOnlyCollection<string> TelephoneNumbers { get; set; }
    }
}
