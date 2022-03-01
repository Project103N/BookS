using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public Author Authors { get; set; }
        public int PageCount { get; set; }
        public int UnitPrice { get; set; }
        public string Details { get; set; }
        public DateTime PublishDate { get; set; }
        public int UnitsInStock { get; set; }
        public bool IsActive { get; set; }
        public int TotalSell { get; set; }
    }
}