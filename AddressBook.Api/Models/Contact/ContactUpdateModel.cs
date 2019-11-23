using System;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Api.Models.Contact
{
    public class ContactUpdateModel
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
