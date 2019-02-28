using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMarketApi.Models;

namespace BookMarketApi.Resources
{
    public class SaveResponse : BaseResponse
    {
        public Book Book { get; private set; }

        private SaveResponse(bool success, string message, Book book) : base(success, message)
        {
            Book = book;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="book">Saved book.</param>
        /// <returns>Response.</returns>
        public SaveResponse(Book book) : this(true, string.Empty, book)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveResponse(string message) : this(false, message, null)
        { }

    }
}
