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
            ViewBag.MovieTitle = MovieDAL.GetSearchResult("GhostBusters");
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
        public ActionResult Registration()
        {
            return View();
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
    }
}