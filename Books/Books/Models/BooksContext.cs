using System;
using System.Data.Entity;
using System.Linq;
using Books.Models;

namespace Books.Models
{
    public class BooksContext : DbContext
    {
        // Your context has been configured to use a 'BooksContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Books.Models.BooksContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BooksContext' 
        // connection string in the application configuration file.
        public BooksContext()
            : base("name=DefaultConnection")
        {

        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
    }
}