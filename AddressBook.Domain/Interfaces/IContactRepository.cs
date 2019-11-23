using AddressBook.Domain.Models;
using System;
using System.Threading.Tasks;

namespace AddressBook.Domain.Interfaces
{
    public interface IContactRepository
    {
        Task<PagedList<Contact>> GetAsync(int pageNumber, int pageSize);
        Task<Contact> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(Contact entity);
        Task<bool> UpdateAsync(Contact entity);
        Task<bool> DeleteAsync(Contact entity);
        Task<bool> ExistsAsync(Guid id);
        Task<Contact> FindAsync(string name, string address);
    }
}
