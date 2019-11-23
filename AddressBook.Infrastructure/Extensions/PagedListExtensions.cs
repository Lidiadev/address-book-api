using AddressBook.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Infrastructure.Extensions
{
    public static class PagedListExtensions
    {
        public async static Task<PagedList<T>> Create<T>(IQueryable<T> dataSource, int pageNumber, int pageSize)
        {
            var items = await dataSource.Skip((pageNumber - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToListAsync();

            var count = dataSource.Count();

            return new PagedList<T>(items, pageNumber, pageSize, count);
        }
    }
}
