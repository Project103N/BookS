using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Books.Models;

namespace Books.Repositories
{
    public class Addresses_EF_Repository : IRepository<Address, int>
    {
        private ApplicationDbContext _db { get; set; }
        public ApplicationDbContext db
        {
            get
            {
                if (_db == null)
                {
                    _db = new ApplicationDbContext();
                }
                return _db;
            }
        }

        public void Add(Address entity)
        {
            db.Addresses.Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<Address> Get()
        {
            return db.Addresses.ToList();
        }

        public Address Get(int id)
        {
            return db.Addresses.Find(id);
        }

        public void Remove(Address entity)
        {
            db.Addresses.Remove(entity);
            db.SaveChanges();
        }

        public void Update(Address entity)
        {
            Address updatedAddress = db.Addresses.Attach(entity);
            db.Entry(updatedAddress).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}