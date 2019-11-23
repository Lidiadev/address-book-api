using AddressBook.Domain.Dtos;
using AddressBook.Domain.Dtos.Contacts;
using System;
using System.Threading.Tasks;

namespace AddressBook.Domain.Interfaces
{
    public interface IContactService
    {
        Task<PagedListDto<ContactDetailsDto>> GetPaginatedAsync(ContactsQueryDto queryDto);
        Task<ContactDetailsDto> GetByIdAsync(Guid id);
        Task<ContactDetailsDto> AddAsync(ContactCreateDto contactDto);
        Task UpdateContactAsync(ContactUpdateDto contactDto);
        Task DeleteContactAsync(Guid id);
        Task<bool> ContactExists(Guid authorId);
    }
}
