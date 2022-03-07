using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Books.Models;
using Books.Repositories;

namespace Books.Controllers
{
    public class OrdersController : Controller
    {
        private Orders_EF_Repository _repository { get; set; }
        private Orders_EF_Repository repository
        {
            get
            {
                if (_repository == null)
                    _repository = new Orders_EF_Repository();
                return _repository;
            }
        }

        // GET: Orders
        public ActionResult Index()
        {
            
            return View(repository.Get());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {         
            Order order = repository.Get(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            //ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Title");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,AddressID")] Order order)
        {
            if (ModelState.IsValid)
            {
                repository.Add(order);
                return RedirectToAction("Index");
            }

            //ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Title", order.AddressID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            Order order = repository.Get(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            //ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Title", order.AddressID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,AddressID")] Order order)
        {
            if (ModelState.IsValid)
            {
               repository.Update(order);
                return RedirectToAction("Index");
            }
            //ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Title", order.AddressID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            Order order = repository.Get(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = repository.Get(id);
            repository.Remove(order);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
