using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMarketApi.Models;
using BookMarketApi.Repositories;
using BookMarketApi.Resources;

namespace BookMarketApi.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> bookRepository;
        private readonly IUnitOfWork unitOfWork;

        public BookService(IRepository<Book> bookRepo, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.bookRepository = bookRepo;
        }

        public async Task<IEnumerable<Book>> ListAsync()
        {
            return await bookRepository.ListAsync(); 
        }

        public async Task SaveAsync(Book book)
        {           
                await bookRepository.AddAsync(book);
                await unitOfWork.CompleteAsync(); 
        }

        public async Task UpdateAsync(int id, Book book)
        {
            var checkBook = await bookRepository.FindByIdAsync(id);

            if(checkBook == null)            
                return;
            

            checkBook.Name = book.Name;
            checkBook.Author = book.Author;
            checkBook.Price = book.Price;
            checkBook.Description = book.Description;

            bookRepository.Update(checkBook);

            await unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var checkBook = await bookRepository.FindByIdAsync(id);

            if (checkBook == null)
                return;

            bookRepository.Remove(checkBook);
            await unitOfWork.CompleteAsync();
        }
    }
}
