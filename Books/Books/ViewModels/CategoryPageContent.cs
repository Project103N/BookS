using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Books.Models;

namespace Books.ViewModels
{
    public class CategoryPageContent
    {
        [Key]
        public int ID { get; set; }
        public IEnumerable<Book> NewBooks { get; set; }
        public IEnumerable<Book> AllCategoryBooks { get; set; }
    }
}