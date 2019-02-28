using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMarketApi.AppDbContext;
using BookMarketApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookMarketApi.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private readonly BookDbContext bookContext;

        public BookRepository(BookDbContext bookCont)
        {
            this.bookContext = bookCont;
        }

        public async Task<IEnumerable<Book>> ListAsync()
        {
            return await bookContext.Books.ToListAsync();
        }

        public async Task AddAsync(Book book)
        {
            await bookContext.Books.AddAsync(book);
        }

        public async Task<Book> FindByIdAsync(int id)
        {
            return await bookContext.Books.FindAsync(id);
        }

        public void Update(Book book)
        {
            bookContext.Books.Update(book);
        }

        public void Remove(Book book)
        {
            bookContext.Books.Remove(book);
        }
    }
}
