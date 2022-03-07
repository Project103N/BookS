using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Books.ViewModels;
using BookS.Models;
using Books.Repositories;

namespace Books.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        //HomePageContainer content = new HomePageContainer();


        Book_EF_Repository _dbBooks { get; set; }
        Book_EF_Repository dbBooks {
            get {
                if (_dbBooks == null)
                    _dbBooks = new Book_EF_Repository();
                return _dbBooks;
            }
        }

        Category_EF_Repository _dbCategories { get; set; }
        Category_EF_Repository dbCategories
        {
            get {
                if(_dbCategories == null)
                    _dbCategories = new Category_EF_Repository();
                return _dbCategories;
            }
        }
        public ActionResult Index()
        {
            //content.Categories = db.Categories.ToList();
            //content.TopSellers = 
            //return View(db.Books.OrderByDescending(c => c.UnitsInStock).ToList());
            //return View(Price(10,25));
            //return View(SortByPublishDate());
            //return View(SortByPrice());
            //return View(FilterByName("Kurtlar"));

            HomePageContainer hpc = new HomePageContainer();
            hpc.Categories = db.Categories.ToList();
            hpc.Prices = dbBooks.Price(5,200);
            //hpc.CurrentUser = (ApplicationUser)System.Web.HttpContext.Current.User.Identity;
            hpc.AuthorsOfMonth = db.Authors.ToList();
            hpc.TopSellers = dbBooks.Get().ToList();
            return View(hpc);
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

        public ActionResult Category(int id)
        {
            CategoryPageContent cpc = new CategoryPageContent();
            cpc.NewBooks = dbCategories.GetAllCategoryBooks(id).OrderByDescending(b=>b.PublishDate).Take(2);
            // TODO: Bu metoda sayı limiti eklenebilir. Overload olarak.

            cpc.AllCategoryBooks = dbCategories.GetAllCategoryBooks(id);
            return View(cpc);
        }

        public ActionResult Author(int id)
        {
            AuthorPageContent apc = new AuthorPageContent();
            apc.Author = db.Authors.Find(id);
            apc.AuthorsBooks = db.Books.Where(b => b.Author.AuthorID == id).ToList();
            return View(apc);
        }

        //public ActionResult Book(int id)
        //{ 
            // TODO: ViewModel ve View eklenecek.: Cem
        //}
    }
}