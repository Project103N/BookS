using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.Models
{
    public class Cart
    {
        public int TotalPrice { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}