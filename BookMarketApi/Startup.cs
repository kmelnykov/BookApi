using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BookMarketApi.AppDbContext;
using BookMarketApi.Services;
using BookMarketApi.Repositories;
using BookMarketApi.Models;

namespace BookMarketApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<BookDbContext>(options =>
            {
                options.UseInMemoryDatabase("book-api");
            });

            services.AddScoped<IRepository<Book>, BookRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper();
            
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseMvc();

        }
    }
}
