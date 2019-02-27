using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Movie_API_Project.Models;

namespace Movie_API_Project.Controllers
{
    public class MovieFavoritesController : Controller
    {
        private DBMovieContext db = new DBMovieContext();

        // GET: MovieFavorites
        public ActionResult Index()
        {
            return View(db.MovieFavorite.ToList());
        }

        // GET: MovieFavorites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieFavorite movieFavorite = db.MovieFavorite.Find(id);
            if (movieFavorite == null)
            {
                return HttpNotFound();
            }
            return View(movieFavorite);
        }

        public ActionResult Create(string title, string year, string type, string poster)
        {
            MovieFavorite temp = new MovieFavorite( title,  poster,  year,  type);

               db.MovieFavorite.Add(temp);
               db.SaveChanges();
               return RedirectToAction("Index");

        }

        // GET: MovieFavorites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieFavorite movieFavorite = db.MovieFavorite.Find(id);
            if (movieFavorite == null)
            {
                return HttpNotFound();
            }
            return View(movieFavorite);
        }

        // POST: MovieFavorites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Poster,ReleaseYear,Type")] MovieFavorite movieFavorite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieFavorite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movieFavorite);
        }

        // GET: MovieFavorites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieFavorite movieFavorite = db.MovieFavorite.Find(id);
            if (movieFavorite == null)
            {
                return HttpNotFound();
            }
            return View(movieFavorite);
        }

        // POST: MovieFavorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieFavorite movieFavorite = db.MovieFavorite.Find(id);
            db.MovieFavorite.Remove(movieFavorite);
            db.SaveChanges();
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
