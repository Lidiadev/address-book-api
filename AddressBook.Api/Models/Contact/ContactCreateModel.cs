using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Api.Models.Contact
{
    public class ContactCreateModel
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }

        [Required]
        public ICollection<PhoneCreateModel> PhoneList { get; set; }
    }
}
