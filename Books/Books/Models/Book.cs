using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Books.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace Books.Models
{
    public class Book
    {
        public Book()
        {
            this.Categories = new HashSet<Category>();
        }

        public int BookId { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public int PageCount { get; set; }
        public decimal UnitPrice { get; set; }
        public string Details { get; set; }
        public DateTime PublishDate { get; set; }
        public int UnitsInStock { get; set; }
        public bool IsActive { get; set; }
        public decimal TotalSell { get; set; }
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
        public ICollection<Category> Categories { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        


    }
}