using AddressBook.Api.Models.Contact;
using AddressBook.Domain.Dtos.Contacts;
using AddressBook.Domain.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace AddressBook.Api.Mappers
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<GetContactsQueryModel, ContactsQueryDto>();

            CreateMap<Contact, ContactDetailsDto>()
                 .ForMember(
                dest => dest.TelephoneNumbers,
                opt => opt.MapFrom(src => src.TelephoneNumbers.Select(x => x.Value)))
                 .ForMember(
                dest => dest.DateOfBirth,
                opt => opt.MapFrom(src => src.DateOfBirth));

            CreateMap<ContactDetailsDto, ContactDetailsModel>()
                 .ForMember(
                dest => dest.TelephoneNumbers,
                opt => opt.MapFrom(src => src.TelephoneNumbers)); ;

            CreateMap<ContactCreateModel, ContactCreateDto>()
                .ForMember(
                dest => dest.TelephoneNumbers, 
                opt => opt.MapFrom(src => src.PhoneList.Select(x => x.Phone)));

            CreateMap<ContactCreateDto, Contact>();

            CreateMap<ContactUpdateModel, ContactUpdateDto>();

            CreateMap<ContactUpdateDto, Contact>();

            CreateMap<List<ContactDetailsDto>, List<ContactDetailsModel>>();
        }
    }
}
