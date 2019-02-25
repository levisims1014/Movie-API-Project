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
        
        public static List<string> GetData(string Url)
        {
            HttpWebRequest request = WebRequest.CreateHttp(Url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());
            string data = rd.ReadToEnd();
            JObject movieJson = JObject.Parse(data);
            // string title = movieJson["Search"][0]["Title"].ToString();
            // return title;

            List<JToken> searchResults = movieJson["Search"].ToList();
            List<string> titleList = new List<string>();
            foreach (var titles in searchResults)
            {
                titleList.Add(titles["Title"].ToString());
            }
            return titleList;
        }

        public static List<string> GetSearchResult(string search)
        {
            //http://www.omdbapi.com/?i=tt3896198&apikey=c2c5c13d
            //string url = "http://www.omdbapi.com/?s=" + txtMovieName.Text.Trim() + "&apikey=XXXX";

            List<string> output = GetData("http://www.omdbapi.com/?s=" + search.Trim() + "&apikey=c2c5c13d");
            //RedditPost rp = new RedditPost(output, i);

            return output;
        }
    }
}