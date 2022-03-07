using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Books.Models;

namespace Books.ViewModels
{
    public class AuthorPageContent
    {
        [Key]
        public int ID { get; set; }
        public ICollection<Book> AuthorsBooks { get; set; }
        public Author Author { get; set; }
    }
}