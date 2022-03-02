using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Books.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public int TotalPrice { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; }
    }
}