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
            ViewBag.MovieTitle = MovieDAL.GetSearchResult("Ghostbusters");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            ViewBag.Test = "Hey, this is a test.";
            
            ViewBag.Message = "This is the second test";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}