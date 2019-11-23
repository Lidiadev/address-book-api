using System.ComponentModel.DataAnnotations;

namespace AddressBook.Api.Models.Contact
{
    public class PhoneCreateModel
    {
        [Phone]
        public string Phone { get; set; }
    }
}
