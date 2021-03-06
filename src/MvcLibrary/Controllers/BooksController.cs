using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcLibrary.Data;
using MvcLibrary.Models;

namespace MvcLibrary.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index(string bookGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.Book orderby b.Genre select b.Genre;

            // Select all books.
            var books = from b in _context.Book.Include(b => b.Author) select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                // Select the books based on the searchString parameter.
                books = books.Where(s => s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(bookGenre))
            {
                // Select the books based on the bookGenre parameter.
                books = books.Where(x => x.Genre == bookGenre);
            }

            var bookGenreVM = new BookGenreViewModel();
            bookGenreVM.genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            bookGenreVM.books = await books.ToListAsync();

            return View(bookGenreVM);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.SingleOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "Name");

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.Book orderby b.Genre select b.Genre;
            ViewData["Genre"] = new SelectList(genreQuery.Distinct().ToList());

            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AuthorId,Genre,Price,Title,Year")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "Name", book.Author);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.SingleOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "Name", book.Author);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AuthorId,Genre,Price,Title,Year")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "Name", book.Author);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.SingleOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Book.SingleOrDefaultAsync(m => m.Id == id);
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }

        // Will return: quantity of books, quantity of authors, most expensive book, cheapest book, sum of book's prices
        public IActionResult Statistics()
        {
            // Returns the author quantity.
            var author = from a in _context.Author select a;
            int authorQuantity = author.Count();

            // Returns the book quantity.
            var book = from b in _context.Book select b;
            int bookQuantity = book.Count();

            // Returns the book with the lowest price.
            decimal lowestPrice = book.Min(x => x.Price);
            var cheapestBook = book.First(x => x.Price == lowestPrice);

            // Returns the book with the highest price
            decimal highestPrice = book.Max(x => x.Price);
            var mostExpensiveBook = book.First(x => x.Price == highestPrice);

            // Returns the sum of the book's price
            decimal totalPrice = book.Select(c => c.Price).Sum();

            // Create new BookStatistics object, setting its attributes.
            var bookStatistics = new BookStatistics();
            bookStatistics.AuthorQuantity = authorQuantity;
            bookStatistics.BookQuantity = bookQuantity;
            bookStatistics.cheapestBook = cheapestBook;
            bookStatistics.mostExpensiveBook = mostExpensiveBook;
            bookStatistics.TotalPrice = totalPrice;

            return View(bookStatistics);
        }
    }
}
