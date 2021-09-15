using BOT.Model;
using Db.Bot;
using Flurl;
using Flurl.Http;
using HtmlAgilityPack;
using Mirai.Net.Data.Messages.Receivers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Actions.SearchImage
{
    class SearchImageAction
    {
        public static async Task<List<ImageModel>> imgAsync(string uri)
        {
            var client = new RestClient("https://ascii2d.net/search/uri");

            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0");
            request.Timeout = 10000;
            request.AddHeader("Cache-Control", "no-cache");
            request.AddParameter("utf8", "✓");
            request.AddParameter("authenticity_token", "✓");
            request.AddParameter("uri", $"{uri}");
            request.AddParameter("search", "");



            var response = await client.ExecuteAsync(request);
            Console.WriteLine(response.ResponseUri);
            //Console.WriteLine(response.Content);

            var htmldoc = doch(response.Content);
            var mainParse = "//*[@class='row item-box']";
            var mainNode = htmldoc.DocumentNode.SelectNodes(mainParse);
            var length = 0;
            if (mainNode != null)
            {
                if (mainNode.Count > 3)
                {
                    length = 3;
                }
                else
                {
                    length = mainNode.Count;
                }
            }
            else
            {
                return null;
            }
          
            var imageInfoList = new List<ImageModel>();
        

            for (int i = 1; i < length; i++)
            {
                var locationParse = "//*[@class='detail-box gray-link']/h6/small";
                var imageUrlParse = "/div/img";
                var imageDetailParse = "//*[@class='detail-box gray-link']/h6/a[1]";
                var imageAuthorParse = "//*[@class='detail-box gray-link']/h6/a[2]";

                var nc = doch(mainNode[i].InnerHtml);

                var imageUrlNode = nc.DocumentNode.SelectSingleNode(imageUrlParse);
                var locationNode = nc.DocumentNode.SelectSingleNode(locationParse);
                var imageAuthorNode = nc.DocumentNode.SelectSingleNode(imageAuthorParse);
                var imageDetailNode = nc.DocumentNode.SelectSingleNode(imageDetailParse);

                var location = "不存在";

                if (locationNode !=null)
                {
                    location = locationNode.InnerText;
                }
                else
                {
                    locationParse = "//*[@class='external']/small";
                    locationNode = nc.DocumentNode.SelectSingleNode(locationParse);
                    location = locationNode.InnerText;
                }


                var imageAuthorUrl = "不存在";
                var authorName = "未知";
                if (imageAuthorNode != null)
                {
                    imageAuthorUrl = imageAuthorNode.Attributes["href"].Value;
                    authorName = imageAuthorNode.InnerText;
                }
                else
                {
                    imageAuthorParse = "//*[@class='external']/a[2]";
                    imageAuthorNode = nc.DocumentNode.SelectSingleNode(imageAuthorParse);
                    authorName = imageAuthorNode.InnerText;
                    imageAuthorUrl = imageAuthorNode.Attributes["href"].Value;
                }

                var imageName = "";
                var imageDetailUrl = "";
                if (imageDetailNode != null)
                {
                    imageName = imageDetailNode.InnerText;
                    imageDetailUrl = imageDetailNode.Attributes["href"].Value;
                }
                else
                {
                    imageDetailParse = "//*[@class='external']/a[1]";
                    imageDetailNode= nc.DocumentNode.SelectSingleNode(imageDetailParse);
                    imageName = imageDetailNode.InnerText;
                    imageDetailUrl = imageDetailNode.Attributes["href"].Value;
                }


                var imageUrl = imageUrlNode.Attributes["src"].Value;

                if (locationNode != null)
                {
                    var m = new ImageModel
                    {
                        DetailUrl = imageDetailUrl,
                        ImageAuthorUrl = imageAuthorUrl,
                        PreImageUrl = "https://ascii2d.net" + imageUrl,
                        AuthorName = authorName,
                        ImageName = imageName,
                        ImageLocation = location
                    };
                    imageInfoList.Add(m);
                }
            }

            return imageInfoList;
        }

        private static HtmlDocument doch(string html)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            return htmlDoc;
        }


    }
}
