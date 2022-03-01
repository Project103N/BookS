using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int AddressID { get; set; }
        public Address Address { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}