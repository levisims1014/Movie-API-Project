using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Movie_API_Project.Models
{
    public class MovieDAL
    {
        
        public static List<MovieFavorite> GetData(string Url)
        {
            HttpWebRequest request = WebRequest.CreateHttp(Url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());
            string data = rd.ReadToEnd();
            JObject movieJson = JObject.Parse(data);

            List<JToken> searchResults = movieJson["Search"].ToList();
            List<MovieFavorite> movies = new List<MovieFavorite>();
            foreach (var item in searchResults)
            {
                //stringlist.add(item["Title"].ToString());
                MovieFavorite temp = new MovieFavorite(item["Title"].ToString(), item["Poster"].ToString(), item["Year"].ToString(), item["Type"].ToString());
                movies.Add(temp);
            }
            return movies;
        }

        public static List<MovieFavorite> GetSearchResult(string search)
        {
            //http://www.omdbapi.com/?i=tt3896198&apikey=c2c5c13d
            //string url = "http://www.omdbapi.com/?s=" + txtMovieName.Text.Trim() + "&apikey=XXXX";

            List<MovieFavorite> output = GetData("http://www.omdbapi.com/?s=" + search.Trim() + "&apikey=c2c5c13d");
            //RedditPost rp = new RedditPost(output, i);

            return output;
        }
    }
}