using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Books.Models;

namespace Books.Repositories
{
    public class Book_EF_Repository : IRepository<Book, int>
    {
        private ApplicationDbContext _db { get; set; }
        public ApplicationDbContext db
        {
            get
            {
                if (_db == null)
                    _db = new ApplicationDbContext();
                return _db;
            }
        }

        public void Add(Book entity)
        {
            db.Books.Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<Book> Get()
        {
            return db.Books.Include(b => b.Author).Include(b => b.Publisher).ToList() ;
        }

        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        public void Remove(Book entity)
        {
            db.Books.Remove(entity);
            db.SaveChanges();
        }

        public void Update(Book entity)
        {
            var updatedBook = db.Books.Attach(entity);
            db.Entry(updatedBook).State = EntityState.Modified;
            db.SaveChanges();
        }

        public List<Book> Price(int min, int max)
        {
            //content.PriceRanges = db.Books.Where(x => (x.UnitPrice >= min && x.UnitPrice <= max)).ToList();
            return db.Books.Where(x => (x.UnitPrice >= min && x.UnitPrice <= max)).ToList();
        }
        public List<Book> SortByPublishDate()
        {
            return db.Books.OrderByDescending(x => x.PublishDate).ToList();
        }
        public List<Book> SortByPrice()
        {

            return db.Books.OrderByDescending(x => x.UnitPrice).ToList();
        }
        public List<Book> FilterByName(string name)
        {
            return db.Books.Where(x => x.Name.Contains(name)).ToList();
        }
    }
}