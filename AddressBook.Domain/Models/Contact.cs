using AddressBook.Domain.Dtos.Contacts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AddressBook.Domain.Models
{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Address { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public ICollection<TelephoneNumber> TelephoneNumbers { get; set; }
            = new List<TelephoneNumber>();

        public Contact()
        {
        }

        public Contact(ContactCreateDto dto)
        {
            Name = dto.Name;
            Address = dto.Address;

            if (dto.TelephoneNumbers.Any())
            {
                foreach (var telephoneNumber in dto.TelephoneNumbers)
                {
                    TelephoneNumbers.Add(new TelephoneNumber
                    {
                        Id = Guid.NewGuid(),
                        Value = telephoneNumber
                    });
                }
            }
        }
    }
}
