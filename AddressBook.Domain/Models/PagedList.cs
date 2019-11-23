using System;
using System.Collections.Generic;

namespace AddressBook.Domain.Models
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }

        public int PageSize { get; private set; }

        public int TotalPages { get; private set; }

        public int TotalCount { get; private set; }

        public PagedList()
        {

        }

        public PagedList(List<T> items, int pageNumber, int pageSize, int count)
        {
            PageSize = items.Count;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;

            AddRange(items);
        }
    }
}
