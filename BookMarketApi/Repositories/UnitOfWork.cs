using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMarketApi.AppDbContext;

namespace BookMarketApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookDbContext bookContext;

        public UnitOfWork(BookDbContext context)
        {
            this.bookContext = context;
        }

        public async Task CompleteAsync()
        {
            await bookContext.SaveChangesAsync();
        }
    }
}
