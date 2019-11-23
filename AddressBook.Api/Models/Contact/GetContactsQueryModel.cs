namespace AddressBook.Api.Models.Contact
{
    public class GetContactsQueryModel
    {
        private int _pageSize = 15;
        private const int maxPageSize = 30;

        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) 
                               ? maxPageSize 
                               : value;
        }
    }
}
