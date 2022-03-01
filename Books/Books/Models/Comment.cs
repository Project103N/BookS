using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public string CommentText { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        public bool IsApproved { get; set; }
        public ApplicationUser User { get; set; }
        public Book Book { get; set; }
       
    }
}