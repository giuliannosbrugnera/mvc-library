using System.ComponentModel.DataAnnotations;

namespace MvcLibrary.Models
{
    public class BookStatistics
    {
        [Display(Name = "Quantity of Books")]
        public int BookQuantity { get; set; }

        [Display(Name = "Quantity of Authors")]
        public int AuthorQuantity { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Most expensive book")]
        public decimal HighestPrice { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Cheapest book")]
        public decimal LowestPrice { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Total book's price")]
        public decimal TotalPrice { get; set; }
    }
}
