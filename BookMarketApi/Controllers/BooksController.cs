using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookMarketApi.Services;
using BookMarketApi.Models;
using BookMarketApi.Resources;
using BookMarketApi.Extensions;
using AutoMapper;

namespace BookMarketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IBookService bookService;
        private readonly IMapper mapper;

        public BooksController(IBookService bookServ, IMapper mapper)
        {
            this.mapper = mapper;
            this.bookService = bookServ;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            var books = await bookService.ListAsync();
            return books;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveBook saveBook)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var book = mapper.Map<SaveBook, Book>(saveBook);

            await bookService.SaveAsync(book);

            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveBook saveBook)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var book = mapper.Map<SaveBook, Book>(saveBook);
            await bookService.UpdateAsync(id, book);

            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            
            await bookService.DeleteAsync(id);

            return Ok();

        }
    }
}