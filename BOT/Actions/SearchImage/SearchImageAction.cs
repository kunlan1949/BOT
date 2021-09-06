using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Actions.SearchImage
{
    class SearchImageAction
    {
        public static async Task<string> imgAsync(string uri)
        {

            // Flurl will use 1 HttpClient instance per host
            await "https://ascii2d.net".WithHeaders(new { Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8" ,
                ContentType = "application/x-www-form-urlencoded"
            })
                .PostJsonAsync(new
                {
                    utf8 = "✓",
                    authenticity_token = "+XBwOBIv3BZN+BJlN9BcyLN9OBG7UIhO8BWx5jUEWmGpwOHbT86jU309r4/GSGsA+ydryttzSVai6T1+h5Pelw==",
                    uri = uri,
                    search = ""
                }).ContinueWith((e) =>
                {
                    var head = e.Result.Headers;
                    Console.WriteLine(head);
                });
            return "";
        }
    }
}
