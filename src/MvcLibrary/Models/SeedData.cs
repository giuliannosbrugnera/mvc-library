using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcLibrary.Data;
using System;
using System.Linq;

namespace MvcLibrary.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any books or authors.
                if (context.Book.Any() || context.Author.Any())
                {
                    return;   // DB has been seeded
                }

                context.Author.AddRange(
                    new Author() { Name = "Jane Austen" },
                    new Author() { Name = "Charles Dickens" },
                    new Author() { Name = "Miguel de Cervantes" },
                    new Author() { Name = "George Martin" },
                    new Author() { Name = "Dan Brown" },
                    new Author() { Name = "J. R. R. Tolkien" },
                    new Author() { Name = "J. K. Rowling" }
                );

                context.Book.AddRange(
                    new Book()
                    {
                        Title = "Pride and Prejudice",
                        Year = 1813,
                        AuthorId = 1,
                        Price = 9.99M,
                        Genre = "Comedy of manners"
                    },
                    new Book()
                    {
                        Title = "Northanger Abbey",
                        Year = 1817,
                        AuthorId = 1,
                        Price = 12.95M,
                        Genre = "Gothic parody"
                    },
                    new Book()
                    {
                        Title = "David Copperfield",
                        Year = 1850,
                        AuthorId = 2,
                        Price = 15,
                        Genre = "Bildungsroman"
                    },
                    new Book()
                    {
                        Title = "Don Quixote",
                        Year = 1617,
                        AuthorId = 3,
                        Price = 8.95M,
                        Genre = "Picaresque"
                    },
                    new Book()
                    {
                        Title = "A Game of Thrones",
                        Year = 1996,
                        AuthorId = 4,
                        Price = 30,
                        Genre = "Fantasy"
                    },
                    new Book()
                    {
                        Title = "A Clash of Kings",
                        Year = 1998,
                        AuthorId = 4,
                        Price = 30,
                        Genre = "Fantasy"
                    },
                    new Book()
                    {
                        Title = "A Storm of Swords",
                        Year = 2000,
                        AuthorId = 4,
                        Price = 35,
                        Genre = "Fantasy"
                    },
                    new Book()
                    {
                        Title = "A Feast for Crows",
                        Year = 2005,
                        AuthorId = 4,
                        Price = 38,
                        Genre = "Fantasy"
                    },
                    new Book()
                    {
                        Title = "A Dance with Dragons",
                        Year = 2011,
                        AuthorId = 4,
                        Price = 40,
                        Genre = "Fantasy"
                    },
                    new Book()
                    {
                        Title = "Digital Fortress",
                        Year = 1998,
                        AuthorId = 5,
                        Price = 25,
                        Genre = "Fiction"
                    },
                    new Book()
                    {
                        Title = "Deception Point",
                        Year = 2001,
                        AuthorId = 5,
                        Price = 25,
                        Genre = "Fiction"
                    },
                    new Book()
                    {
                        Title = "Angels & Demons",
                        Year = 2000,
                        AuthorId = 5,
                        Price = 45,
                        Genre = "Fiction"
                    },
                    new Book()
                    {
                        Title = "The Da Vinci Code",
                        Year = 2003,
                        AuthorId = 5,
                        Price = 50,
                        Genre = "Fiction"
                    },
                    new Book()
                    {
                        Title = "The Lost Symbol",
                        Year = 2009,
                        AuthorId = 5,
                        Price = 36,
                        Genre = "Fiction"
                    },
                    new Book()
                    {
                        Title = "Inferno",
                        Year = 2013,
                        AuthorId = 5,
                        Price = 55,
                        Genre = "Fiction"
                    },
                    new Book()
                    {
                        Title = "The Hobbit",
                        Year = 1937,
                        AuthorId = 6,
                        Price = 20,
                        Genre = "Fiction"
                    },
                    new Book()
                    {
                        Title = "The Lord of The Rings: The Fellowship of the Ring",
                        Year = 1954,
                        AuthorId = 6,
                        Price = 30,
                        Genre = "Fiction"
                    },
                    new Book()
                    {
                        Title = "The Lord of the Rings: The Two Towers",
                        Year = 1954,
                        AuthorId = 6,
                        Price = 35,
                        Genre = "Fiction"
                    },
                    new Book()
                    {
                        Title = "The Lord of the Rings: The Return of the King",
                        Year = 1955,
                        AuthorId = 6,
                        Price = 40,
                        Genre = "Fiction"
                    },
                    new Book()
                    {
                        Title = "Harry Potter and the Philosopher's Stone",
                        Year = 1997,
                        AuthorId = 7,
                        Price = 15,
                        Genre = "Fantasy"
                    },
                    new Book()
                    {
                        Title = "Harry Potter and the Chamber of Secrets",
                        Year = 1998,
                        AuthorId = 7,
                        Price = 17,
                        Genre = "Fantasy"
                    },
                    new Book()
                    {
                        Title = "Harry Potter and the Prisoner of Azkaban",
                        Year = 1999,
                        AuthorId = 7,
                        Price = 18,
                        Genre = "Fantasy"
                    },
                    new Book()
                    {
                        Title = "Harry Potter and the Goblet of Fire",
                        Year = 2000,
                        AuthorId = 7,
                        Price = 20,
                        Genre = "Fantasy"
                    },
                    new Book()
                    {
                        Title = "Harry Potter and the Order of the Phoenix",
                        Year = 2003,
                        AuthorId = 7,
                        Price = 23,
                        Genre = "Fantasy"
                    },
                    new Book()
                    {
                        Title = "Harry Potter and the Half-Blood Prince",
                        Year = 2005,
                        AuthorId = 7,
                        Price = 30,
                        Genre = "Fantasy"
                    },
                    new Book()
                    {
                        Title = "Harry Potter and the Deathly Hallows",
                        Year = 2007,
                        AuthorId = 7,
                        Price = 37,
                        Genre = "Fantasy"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
