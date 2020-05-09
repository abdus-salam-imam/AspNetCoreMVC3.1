using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [StringLength(100,MinimumLength =5)]
        [Required(ErrorMessage ="please enter the title of your book")]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; } 
        public string Language { get; set; }
        [Required]
        [Display(Name ="Total pages of Book")]
        public int? TotalPages { get; set; }
    }
}
