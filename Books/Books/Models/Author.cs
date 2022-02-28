using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string Biography { get; set; }
    }
}