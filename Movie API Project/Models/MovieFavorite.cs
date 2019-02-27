using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.IO;

namespace Movie_API_Project.Models
{
    public class MovieFavorite
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Poster { get; set; }
        public string ReleaseYear { get; set; }
        public string Type { get; set; }

        public MovieFavorite()
        {

        }

        public MovieFavorite(string title, string poster, string year, string type)
        {
            this.Title = title;
            this.Poster = poster;
            this.ReleaseYear = year;
            this.Type = type;
        }
    }

    public class DBMovieContext : DbContext
    {

        public DbSet<MovieFavorite> MovieFavorite { get; set; }

    }
}