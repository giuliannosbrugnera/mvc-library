using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcLibrary.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Author name")]
        public string Name { get; set; }
    }
}
