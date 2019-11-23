using AddressBook.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Infrastructure.Data
{
    public class AddressBookContext : DbContext
    {
        public AddressBookContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<TelephoneNumber> TelephoneNumbers { get; set; }
    }
}
