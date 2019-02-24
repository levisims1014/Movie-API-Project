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
        
        public static string GetData(string Url)
        {
            HttpWebRequest request = WebRequest.CreateHttp(Url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());
            string data = rd.ReadToEnd();
            JObject movieJson = JObject.Parse(data);
            string title = movieJson["Search"][0]["Title"].ToString();
            return title;
        }

        public static string GetSearchResult(string search)
        {
            //http://www.omdbapi.com/?i=tt3896198&apikey=c2c5c13d
            //string url = "http://www.omdbapi.com/?s=" + txtMovieName.Text.Trim() + "&apikey=XXXX";

            string output = GetData("http://www.omdbapi.com/?s=" + search.Trim() + "&apikey=c2c5c13d");
            //RedditPost rp = new RedditPost(output, i);

            return output;
        }
    }
}