using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcLibrary.Models
{
    public class BookGenreViewModel
    {
        public List<Book> books;
        public SelectList genres;
        public string bookGenre { get; set; }
    }
}
