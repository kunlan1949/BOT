using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using static BOT.Model.Game.SignModel;

namespace BOT.Actions.Constellation
{
    public class ConstellationParse
    {
        private static async Task<HtmlDocument> doc(string url)
        {
            var web = new HtmlWeb();
            var htmlDocument = await web.LoadFromWebAsync(url);
            return htmlDocument;
        }

        public static async Task<HtmlDocument> MainParseAsync()
        {
            var htmlDocument =await doc("https://www.d1xz.net/yunshi/");
            return htmlDocument;
        }

        public static async Task<string> luckResultAsync(string parse,HtmlDocument document)
        {
            var result = "";
            var urlNode = document.DocumentNode.SelectSingleNode(parse);
            var url = urlNode.Attributes["href"].Value;

            var resultDocument = await doc("https://www.d1xz.net"+url);
            var resultParse = "//*[@class='txt']/p";
            var resultNode = resultDocument.DocumentNode.SelectSingleNode(resultParse);
            result = resultNode.InnerText;


            return result;
        }



        public static string Parse(Sign sign)
        {
            string str = "";
            switch(sign)
            {
                case Sign.Aries: str = "//*[@class='xzys_left fl']/div[1]/div/div[2]/a"; break;
                case Sign.Taurus: str = "//*[@class='xzys_left fl']/div[2]/div/div[2]/a"; break;
                case Sign.Gemini: str = "//*[@class='xzys_left fl']/div[3]/div/div[2]/a"; break;
                case Sign.Cancer: str = "//*[@class='xzys_left fl']/div[4]/div/div[2]/a"; break;
                case Sign.Leo: str = "//*[@class='xzys_left fl']/div[5]/div/div[2]/a"; break;
                case Sign.Virgo: str = "//*[@class='xzys_left fl']/div[6]/div/div[2]/a"; break;
                case Sign.Libra: str = "//*[@class='xzys_left fl']/div[7]/div/div[2]/a"; break;
                case Sign.Scorpio: str = "//*[@class='xzys_left fl']/div[8]/div/div[2]/a"; break;
                case Sign.Sagittarius: str = "//*[@class='xzys_left fl']/div[9]/div/div[2]/a"; break;
                case Sign.Capricorn: str = "//*[@class='xzys_left fl']/div[10]/div/div[2]/a"; break;
                case Sign.Aquarius: str = "//*[@class='xzys_left fl']/div[11]/div/div[2]/a"; break;
                case Sign.Pisces: str = "//*[@class='xzys_left fl']/div[12]/div/div[2]/a"; break;
            }
            return str;
        }
    }
}
