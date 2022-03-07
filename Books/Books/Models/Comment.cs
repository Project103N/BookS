using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string CommentText { get; set; }
        public DateTime Date { get; set; }
        public bool IsApproved { get; set; }
        public ApplicationUser User { get; set; }

        [ForeignKey("User")]
        public string UserID { get; set; }

        public Book Book { get; set; }
        public int BookID { get; set; }


    }
}