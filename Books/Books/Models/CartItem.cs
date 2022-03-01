using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.Models
{
    public class CartItem
    {
        public int CartItemID { get; set; }
        public Book Book { get; set; }
        public int BookID { get; set; }
        public int Quantity { get; set; }
        public double SubTotalPrice { get; set; }
        public int CartID { get; set; }
        public Cart Cart{ get; set; }
        public bool IsActive { get; set; }

    }
}