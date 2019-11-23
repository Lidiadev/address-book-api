using System;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Domain.Interfaces;
using AddressBook.Domain.Models;
using AddressBook.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Infrastructure.Data
{
    public class ContactRepository : IContactRepository
    {
        private readonly AddressBookContext _dbContext;

        public ContactRepository(AddressBookContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext)); 
        }

        public async Task<PagedList<Contact>> GetAsync(int pageNumber = 1, int pageSize = 30)
        {
            var contacts = _dbContext.Contacts.Include(c => c.TelephoneNumbers) as IQueryable<Contact>;

            return await PagedListExtensions.Create(contacts, pageNumber, pageSize);
        }

        public async Task<Contact> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await _dbContext.Contacts
                                   .Include(c => c.TelephoneNumbers)
                                   .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Guid> AddAsync(Contact entity)
        {
            Validate(entity);

            entity.Id = Guid.NewGuid();

            await _dbContext.Contacts.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<bool> UpdateAsync(Contact entity)
        {
            Validate(entity);

            _dbContext.Entry(entity).State = EntityState.Modified;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Contact entity)
        {
            Validate(entity);

            _dbContext.Contacts.Remove(entity);

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await _dbContext.Contacts.AnyAsync(c => c.Id == id);
        }

        public async Task<Contact> FindAsync(string name, string address)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentNullException(nameof(address));
            }

            return await _dbContext.Contacts.FirstOrDefaultAsync(c => c.Name == name && c.Address == c.Address);
        }

        private static void Validate(Contact entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
        }
    }
}
