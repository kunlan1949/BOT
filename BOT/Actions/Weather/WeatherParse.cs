using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BookServer.NodeParse.Weather.jsonmodel;
using BookServer.NodeParse.Weather.jsonmodel.http;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace BookServer.NodeParse.Weather
{
    public class WeatherParse
    {
        private static async Task<HtmlDocument> doc(string url)
        {
            var web = new HtmlWeb();
            var htmlDocument = await web.LoadFromWebAsync(url);
            return htmlDocument;
        }

        private static HtmlDocument doch(string html)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            return htmlDoc;
        }
        public static WeatherModel WeatherResult(string code)
        {
            ////*[@class='bgwhite_']/div/div[2]/div[3]/div[1]/div/div[6]
            //var htmlDocument = await doc($"http://www.nmc.cn/publish/forecast/" + $"{url}.html");
            //var parse = "//*[@class='bgwhite_']/div";

            //////总页面
            //var statusNode = htmlDocument.DocumentNode.SelectSingleNode(parse);
            //var statusHtml = statusNode.InnerHtml;
            //var statusDoc = doch(statusHtml);
            //////左半部分
            ////var partLeftParse = "/div[1]";
            ////var partLeftNode = statusDoc.Result.DocumentNode.SelectSingleNode(partLeftParse);
            ////var partLeftHtml = partLeftNode.InnerHtml;
            ////var partLeftDoc = doch(partLeftHtml);
            //////右半部分
            ////var partRightParse = "/div[2]";
            ////var partRightNode = statusDoc.Result.DocumentNode.SelectSingleNode(partRightParse);
            ////var partRightHtml = partRightNode.InnerHtml;
            ////var partRightDoc = doch(partRightHtml);


            ////采样时间
            //var tParse = "//div[@id='realPublishTime']";
            //var tNode = statusDoc.Result.DocumentNode.SelectSingleNode(tParse);
            //var currentTime = tNode.InnerText;

            ////当前温度
            //var ctParse = "//*[@id='realTemperature']";
            //var ctNode = statusDoc.Result.DocumentNode.SelectSingleNode(ctParse);
            //var currentTemp = ctNode.InnerText;

            ////体感温度
            //var rfParse = "//*[@id='realFeelst']";
            //var rfNode = statusDoc.Result.DocumentNode.SelectSingleNode(rfParse);
            //var realFeelst = rfNode.InnerText;

            ////最高温度
            //var thParse = "//*[@id='day7']/div[1]/div/div[6]";
            //var thNode = statusDoc.Result.DocumentNode.SelectSingleNode(thParse);
            //var tempHigh = thNode.InnerText;

            ////最低温度
            //var tlParse = "//*[@id='day7']/div[1]/div/div[7]";
            //var tlNode = statusDoc.Result.DocumentNode.SelectSingleNode(tlParse);
            //var tempLow = tlNode.InnerText;

            ////相对湿度
            //var rhParse = "//*[@id='realHumidity']";
            //var rhNode = statusDoc.Result.DocumentNode.SelectSingleNode(rhParse);
            //var relaHumidity = rhNode.InnerText;

            ////降水量
            //var raParse = "//*[@id='realRain']";
            //var raNode = statusDoc.Result.DocumentNode.SelectSingleNode(raParse);
            //var rain = raNode.InnerText;

            ////风
            //var wParse = "//*[@id='realWindDirect']";
            //var sParse = "//*[@id='realWindPower']";
            //var wNode = statusDoc.Result.DocumentNode.SelectSingleNode(wParse);
            //var sNode = statusDoc.Result.DocumentNode.SelectSingleNode(sParse);
            //var windDirect = wNode.InnerText;
            //var windSpeed = sNode.InnerText;
            ////空气质量
            //var airParse = "//*[@id='aqi']";
            //var airhNode = statusDoc.Result.DocumentNode.SelectSingleNode(airParse);
            //var airQuality = airhNode.InnerText;

            ////天气
            //var weParse = "//*[@id='day7']/div[1]/div/div[3]";
            //var weNode = statusDoc.Result.DocumentNode.SelectSingleNode(weParse);
            //var weather = weNode.InnerText;

            string response = HttpApi.HttpGet("http://www.nmc.cn/rest/weather?stationid=" + $"{code}");
            WeatherJsonModel w = JsonConvert.DeserializeObject<WeatherJsonModel>(response);

            var result = new WeatherModel
            {
                CurrentTime = w.data.real.publish_time,
                Rain = w.data.real.weather.rain.ToString(),
                RealFeelst = w.data.real.weather.feelst.ToString(),
                CurrentTemp = w.data.real.weather.temperature.ToString(),
                RelativeHumidity = w.data.real.weather.humidity.ToString(),
                AirQuality = w.data.air.aqi.ToString(),
                Weather = w.data.real.weather.info,
                wind = new Windy() { WindDirect = w.data.real.wind.direct, WindSpeed = w.data.real.wind.power }

            };

            return result;
        }
    }
}
