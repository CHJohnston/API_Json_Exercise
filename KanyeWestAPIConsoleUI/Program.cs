using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace KanyeWestAPIConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            //Get Quote API from Kanye West
            var kanyeURL = "https://api.kanye.rest/";
            var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();


            //Get Quote API from Ron Swanson - It's in an array
            var ronSwansonURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronSwansonResponse = client.GetStringAsync(ronSwansonURL).Result;
            var ronQuote = JArray.Parse(ronSwansonResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

            //Conservation Between Kanye West and Ron Swanson

            for (int i = 1; i <= 5; i++) 
            {
                kanyeResponse = client.GetStringAsync(kanyeURL).Result;
                kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
                Console.WriteLine($"Kanye:  {kanyeQuote}");
                
                ronSwansonResponse = client.GetStringAsync(ronSwansonURL).Result;
                ronQuote = JArray.Parse(ronSwansonResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
                Console.WriteLine($"Ron: {ronQuote}");
                Console.WriteLine();
            }

        }
    }
}
