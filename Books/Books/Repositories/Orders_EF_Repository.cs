using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Books.Models;

namespace Books.Repositories
{
    public class Orders_EF_Repository : IRepository<Order, int>
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

        public void Add(Order entity)
        {
            db.Orders.Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<Order> Get()
        {
            return db.Orders.ToList();
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public void Remove(Order entity)
        {
            db.Orders.Remove(entity);
            db.SaveChanges();
        }

        public void Update(Order entity)
        {
            Order updatedOrder = db.Orders.Attach(entity);
            db.Entry(updatedOrder).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}