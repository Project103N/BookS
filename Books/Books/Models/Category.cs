using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Books.Repositories;

namespace Books.Models
{
    public class Category
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public Category()
        {
            this.Books = new HashSet<Book>();
        }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}