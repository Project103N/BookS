using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.Models
{
    public class Category
    {
        public Category()
        {
            this.Books = new HashSet<Book>();
        }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}