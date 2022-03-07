using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Books.Models;

namespace Books.ViewModels
{
    public class AuthorPageContent
    {
        public ICollection<Book> AuthorsBook { get; set; }
        public Author author { get; set; }
    }
}