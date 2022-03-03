using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Books.Models;

namespace Books.Repositories
{
    public class Category_EF_Repository : IRepository<Category, int>
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

        public void Add(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<Category> Get()
        {
            return db.Categories.ToList();
        }

        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        public void Remove(Category entity)
        {
            db.Categories.Remove(entity);
            db.SaveChanges();
        }

        public void Update(Category entity)
        {
            Category updatedCategory = db.Categories.Attach(entity);
            db.Entry(updatedCategory).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}