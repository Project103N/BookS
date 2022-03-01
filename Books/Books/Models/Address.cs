using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string Detail { get; set; }
        public int ApplicationUserID { get; set; }
        public  ApplicationUser  ApplicationUser{ get; set; }
        

    }
}