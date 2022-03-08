using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Books.Models;

namespace BookS.Models
{
    public class HomePageContainer
    {
        [Key]
        public int ID { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Book> TopSellers { get; set; }
        public ApplicationUser CurrentUser { get; set; }
        public ICollection<Author> AuthorsOfMonth { get; set; }
        public ICollection<Book> PriceRanges { get; set; }
        public ICollection<Book> Prices { get; set; }
        public ICollection<Book> Images { get; set; } //eklendi

    }
}