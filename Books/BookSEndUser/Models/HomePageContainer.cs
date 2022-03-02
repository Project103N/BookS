using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Books.Models;

namespace BookSEndUser.Models
{
    public class HomePageContainer
    {
        public ICollection<Category> Categories { get; set; }
        public ICollection<Book> TopSellers { get; set; }
        public ApplicationUser CurrentUser { get; set; }
        public ICollection<Author> AuthorsOfMonth { get; set; }
    }
}