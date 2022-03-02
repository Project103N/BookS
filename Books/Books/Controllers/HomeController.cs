using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Books.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        //HomePageContainer content = new HomePageContainer();
        public ActionResult Index()
        {
            //content.Categories = db.Categories.ToList();
            //content.TopSellers = 
            return View(db.Books.OrderByDescending(c => c.UnitsInStock).ToList());
            //return View(Price(10,25));
            //return View(SortByPublishDate());
            //return View(SortByPrice());
            //return View(FilterByName("Kurtlar"));
        }

        public List<Book> Price(int min, int max )
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
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}