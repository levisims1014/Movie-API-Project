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
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }
        public string Plot { get; set; }
        public string RunTime { get; set; }
    }

    public class DBMovieContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
    }
}