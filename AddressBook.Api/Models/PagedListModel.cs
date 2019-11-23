using System.Collections.Generic;

namespace AddressBook.Api.Models
{
    public class PagedListModel<T> 
    {
        public List<T> Items { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int TotalCount { get; set; }
    }
}
