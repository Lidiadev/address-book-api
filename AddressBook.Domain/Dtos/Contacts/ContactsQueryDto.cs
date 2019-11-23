namespace AddressBook.Domain.Dtos.Contacts
{
    public class ContactsQueryDto
    {
        public int PageNumber { get; } = 1;

        public int PageSize { get; } = 15;
    }
}
