using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookMarketApi.Models;

namespace BookMarketApi.AppDbContext
{
    public class BookDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>().ToTable("Books");
            builder.Entity<Book>().HasKey(p => p.Id);
            builder.Entity<Book>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Book>().Property(p => p.Name).IsRequired().HasMaxLength(60);
            builder.Entity<Book>().Property(p => p.Price).IsRequired();
            builder.Entity<Book>().Property(p => p.Author).IsRequired().HasMaxLength(80);
            builder.Entity<Book>().Property(p => p.Description).HasMaxLength(300);

            builder.Entity<Book>().HasData
            (
                new Book
                {
                    Name = "A Clockwork Orange",
                    Author = "John Anthony Burgess Wilson",
                    Price = 13,
                    Id = 40,
                    Description = "A Clockwork Orange is a dystopian satirical black comedy novel by English writer Anthony Burgess, " +
                    "published in 1962"
                },
                new Book
                {
                    Name = "The Black Obelisk",
                    Author = "Erich Maria Remarque",
                    Price = 14,
                    Id = 41,
                    Description = "The Black Obelisk is a novel written in 1956 by the German author " +
                    "Erich Maria Remarque. This novel paints a portrait of Germany in the early 1920s, a period marked by " +
                    "hyperinflation and rising nationalism."
                },

                new Book
                {
                    Name = "Do Androids Dream of Electric Sheep?",
                    Author = "Philip Kindred Dick",
                    Price = 11,
                    Id = 42,
                    Description = "The novel is set in a post-apocalyptic San Francisco, where Earth's life has been greatly" +
                    " damaged by nuclear global war."
                },
                new Book
                {
                    Name = "The Idiot",
                    Author = "Fyodor Mikhailovich Dostoevsky",
                    Price = 13,
                    Id = 43,
                    Description = "The title is an ironic reference to the central character of the novel, Prince (Knyaz) " +
                    "Lev Nikolayevich Myshkin, a young man whose goodness, open-hearted simplicity and guilelessness lead" +
                    " many of the more worldly characters he encounters to mistakenly assume that he lacks intelligence and insight."
                }
            );
                
            

        }
    }
}
