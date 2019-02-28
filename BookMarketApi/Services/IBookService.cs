using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMarketApi.Models;
using BookMarketApi.Resources;

namespace BookMarketApi.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> ListAsync();
        Task SaveAsync(Book book);
        Task UpdateAsync(int id, Book book);
        Task DeleteAsync(int id);
    }
}
