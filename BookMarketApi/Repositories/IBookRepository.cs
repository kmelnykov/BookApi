using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMarketApi.Models;

namespace BookMarketApi.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> ListAsync();
        Task AddAsync(T book);
        Task<Book> FindByIdAsync(int id);
        void Update(Book book);
        void Remove(Book book);
    }
}
