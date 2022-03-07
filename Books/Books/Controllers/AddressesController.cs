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
    public class AddressesController : Controller
    {
        private Addresses_EF_Repository _repository;
        private Addresses_EF_Repository repository
        {
            get
            {
                if (_repository == null)
                    _repository = new Addresses_EF_Repository();
                return _repository;
            }
        }

        // GET: Addresses
        public ActionResult Index()
        {
            return View(repository.Get());
        }

        // GET: Addresses/Details/5
        public ActionResult Details(int id)
        {
            Address address = repository.Get(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // GET: Addresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AddressID,Title,City,Town,Detail,ApplicationUserID")] Address address)
        {
            if (ModelState.IsValid)
            {
                repository.Add(address);
                return RedirectToAction("Index");
            }

            return View(address);
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int id)
        {

            Address address = repository.Get(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AddressID,Title,City,Town,Detail,ApplicationUserID")] Address address)
        {
            if (ModelState.IsValid)
            {
                repository.Update(address);
                return RedirectToAction("Index");
            }
            return View(address);
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(int id)
        {
            Address address = repository.Get(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Address address = repository.Get(id);
            repository.Remove(address);
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