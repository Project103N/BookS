using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Books.Models;

namespace Books.ViewModels
{
    public class CategoryPageContent
    {
        public ICollection<Book> NewBooks { get; set; }
        public ICollection<Book> AllCategoryBooks { get; set; }
    }
}