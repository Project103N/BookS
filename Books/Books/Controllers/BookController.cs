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
    public class BookController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
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
        // GET: Book
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Author).Include(b => b.Publisher);
            return View(booksRepository.Get());
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            Book book = booksRepository.Get(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorID", "FullName");
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherID", "PublisherName");
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,Name,AuthorId,PageCount,UnitPrice,Details,PublishDate,UnitsInStock,IsActive,TotalSell,PublisherId")] Book book)
        {
            if (ModelState.IsValid)
            {
                booksRepository.Add(book);
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorID", "FullName", book.AuthorId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherID", "PublisherName", book.PublisherId);
            return View(book);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            Book book = booksRepository.Get(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorID", "FullName", book.AuthorId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherID", "PublisherName", book.PublisherId);
            return View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,Name,AuthorId,PageCount,UnitPrice,Details,PublishDate,UnitsInStock,IsActive,TotalSell,PublisherId")] Book book)
        {
            if (ModelState.IsValid)
            {
                booksRepository.Update(book);
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorID", "FullName", book.AuthorId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherID", "PublisherName", book.PublisherId);
            return View(book);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            Book book = booksRepository.Get(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = booksRepository.Get(id);
            booksRepository.Remove(book);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
