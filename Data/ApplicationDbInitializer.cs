using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_book_api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book_api.Data
{
    public class ApplicationDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                if(!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "book 1 title",
                        Description = "bool 1 description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Genre="Self-help",
                        Author="book 1 author",
                        CoverUrl="https://...",
                        DateAdded=DateTime.Now.AddDays(-1)
                    },
                    new Book()
                    {
                        Title = "book 2 title",
                        Description = "bool 2 description",
                        IsRead = false,
                        Genre = "business",
                        Author = "book 2 author",
                        CoverUrl = "https://...",
                        DateAdded = DateTime.Now.AddDays(-3)
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
