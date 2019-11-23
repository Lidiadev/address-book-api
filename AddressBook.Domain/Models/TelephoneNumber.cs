using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Domain.Models
{
    public class TelephoneNumber
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Value { get; set; }

        [ForeignKey("ContactId")]
        public Contact Contact { get; set; }

        public Guid ContactId { get; set; }
    }
}
