using System;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Domain.Dtos;
using AddressBook.Domain.Dtos.Contacts;
using AddressBook.Domain.Interfaces;
using AddressBook.Domain.Models;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace AddressBook.Domain.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ContactService> _logger;

        public ContactService(IContactRepository contactRepository,
            IMapper mapper,
            ILogger<ContactService> logger)
        {
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<PagedListDto<ContactDetailsDto>> GetPaginatedAsync(ContactsQueryDto queryDto)
        {
            try
            {
                if (queryDto == null)
                    throw new ArgumentNullException(nameof(queryDto));

                var contacts = await _contactRepository.GetAsync(queryDto.PageNumber, queryDto.PageSize);

                return new PagedListDto<ContactDetailsDto>()
                {
                    Items = contacts.Select(x => _mapper.Map<ContactDetailsDto>(x)).ToList(),
                    CurrentPage = contacts.CurrentPage,
                    PageSize = contacts.PageSize,
                    TotalCount = contacts.TotalCount,
                    TotalPages = contacts.TotalPages
                }; 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<ContactDetailsDto> GetByIdAsync(Guid id)
        {
            try
            {
                ValidateId(id);

                var contact = await _contactRepository.GetByIdAsync(id);

                return _mapper.Map<ContactDetailsDto>(contact);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<ContactDetailsDto> AddAsync(ContactCreateDto contactDto)
        {
            try
            {
                if (contactDto == null)
                    throw new ArgumentNullException(nameof(contactDto));

                if (await _contactRepository.FindAsync(contactDto.Name, contactDto.Address) != null)
                    throw new Exception($"Contact cu name {contactDto.Name} and address {contactDto.Address} already exists.");

                var contact = new Contact(contactDto);
                await _contactRepository.AddAsync(contact);

                return _mapper.Map<ContactDetailsDto>(contact);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task UpdateContactAsync(ContactUpdateDto contactDto)
        {
            try
            {
                if (contactDto == null)
                    throw new ArgumentNullException(nameof(contactDto));

                var contactEntity = _mapper.Map<Contact>(contactDto);

                await _contactRepository.UpdateAsync(contactEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task DeleteContactAsync(Guid id)
        {
            try
            {
                var contactEntity = await _contactRepository.GetByIdAsync(id);

                await _contactRepository.DeleteAsync(contactEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<bool> ContactExists(Guid id)
        {
            try
            {
                ValidateId(id);

                return await _contactRepository.ExistsAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        private static void ValidateId(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("Contact id is required.");
        }
    }
}
