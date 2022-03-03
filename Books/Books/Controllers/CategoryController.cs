using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Books.Models;
using Books.ViewModels;
using Books.Repositories;

namespace Books.Controllers
{
    public class CategoryController : Controller
    {
        private Category_EF_Repository _repository { get; set; }
        private Category_EF_Repository repository
        {
            get
            {
                if (_repository == null)
                    _repository = new Category_EF_Repository();
                return _repository;
            }
        }
        private Book_EF_Repository _booksRepository { get; set; }
        private Book_EF_Repository booksRepository
        {
            get
            {
                if (_booksRepository == null)
                    _booksRepository = new Book_EF_Repository();
                return _booksRepository;
            }
        }


        // GET: Category
        public ActionResult Index()
        {
            return View(repository.Get());
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            Category category = repository.Get(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                repository.Add(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = repository.Get(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                repository.Update(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            Category category = repository.Get(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = repository.Get(id);
            repository.Remove(category);
            return RedirectToAction("Index");
        }


        // TODO: parametre olarak kategori id si alınıp. O kategorideki kitaplar listelenecek. Bunun için repository sınıfına metot eklemek gerekecek.
        public ActionResult HomePage()
        {
            CategoryPageContent cpc = new CategoryPageContent();
            cpc.NewBooks = booksRepository.Get();
            cpc.AllCategoryBooks = booksRepository.Get();
            return View(cpc);
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
