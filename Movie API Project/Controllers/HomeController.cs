using Movie_API_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie_API_Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        public ActionResult Welcome(MovieUser user)
        {
            ViewBag.HappyMessage = "Welcome back!" + user.FirstName;
            return View("Welcome");
        }
        public ActionResult AddUser(MovieUser newUser)
        {
            {

                if (ModelState.IsValid)
                {

                    ViewBag.ConfMessage = "Welcome " + newUser.FirstName;
                    ViewBag.Name = $"Name: {newUser.FirstName} {newUser.LastName}";
                    ViewBag.Email = $"Email: {newUser.Email}";

                    return View("Result");
                }
                else
                {
                    ViewBag.ErrorMessage = "Something was invalid. Please fix it and try again.";
                    return View("Registration");
                }
            }
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string Search)
        {
            ViewBag.MovieTitle = MovieDAL.GetSearchResult(Search);
            return View();
        }

        public ActionResult AddFav(MovieFavorite Movies)
        {
            //do something to add Favorite to user's favorites
            return RedirectToAction("Search");

        }
    }
}