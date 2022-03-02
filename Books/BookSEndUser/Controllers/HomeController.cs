using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Books.Models;
using BookSEndUser.Models;

namespace BookSEndUser.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _db { get; set; }
        public ApplicationDbContext db {
            get
            {
                if (_db == null)
                    _db = new ApplicationDbContext();
                return this._db;
            }
        }
        private HomePageContainer _content { get; set; }
        public HomePageContainer content {
            get
            {
                if (_content == null)
                    _content = new HomePageContainer();
                return _content;
            }
            set
            {
                this._content = value;
            } 
        }
        public ActionResult Index()
        {
            content.Categories = db.Categories.ToList();
            content.TopSellers = db.Books.ToList();
            return View(content);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}