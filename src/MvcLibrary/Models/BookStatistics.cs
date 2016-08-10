using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcLibrary.Models
{
    public class BookStatistics
    {
        public int BookCount { get; set; }
        public int AuthorCount { get; set; }
        public decimal HighestPrice { get; set; }
        public decimal LowestPrice { get; set; }
    }
}
