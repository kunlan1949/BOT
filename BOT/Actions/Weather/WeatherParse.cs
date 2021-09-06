using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BookServer.NodeParse.Weather.jsonmodel;
using BookServer.NodeParse.Weather.jsonmodel.http;
using BOT.Utils;
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
            var jsonSetting = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Include};
            jsonSetting.MissingMemberHandling = MissingMemberHandling.Ignore;
            jsonSetting.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            jsonSetting.NullValueHandling = NullValueHandling.Ignore;
            jsonSetting.DefaultValueHandling = DefaultValueHandling.Include;
            jsonSetting.ObjectCreationHandling = ObjectCreationHandling.Auto;
            jsonSetting.TypeNameHandling = TypeNameHandling.Auto;
            WeatherJsonModel w = JsonConvert.DeserializeObject<WeatherJsonModel>(response, jsonSetting);
           
            var currentTime = "无数据";
            var rain = "无数据";
            var realFeelst = "无数据";
            var currentTemp = "无数据";
            var relativeHumidity = "无数据";
            var airQuality = "无数据";
            var weather = "无数据";
            var wind = new Windy() { WindDirect ="未知",WindSpeed ="未知"};
            try
            {
                if (w.data.real.publish_time != null)
                {
                    currentTime = w.data.real.publish_time;
                }
                if (w.data.real.weather.rain.ToString() != null)
                {
                    rain = w.data.real.weather.rain.ToString();
                }
                if (w.data.real.weather.feelst.ToString() != null)
                {
                    realFeelst = w.data.real.weather.feelst.ToString();
                }
                if (w.data.real.weather.temperature.ToString() != null)
                {
                    currentTemp = w.data.real.weather.temperature.ToString();
                }
                if (w.data.real.weather.humidity.ToString() != null)
                {
                    relativeHumidity = w.data.real.weather.humidity.ToString();
                }
                if (w.data.air!= null)
                {
                    airQuality = w.data.air.aqi.ToString();
                }
                if (w.data.predict.detail[0] != null)
                {
                    
                    weather = WeatherUtil.WeatherChoose(w.data.predict.detail[0].day.weather.info, w.data.predict.detail[0].night.weather.info);
                }
                if (w.data.real.wind.direct != null && w.data.real.wind.power !=null)
                {
                    wind = new Windy() { WindDirect = w.data.real.wind.direct, WindSpeed = w.data.real.wind.power };
                }
              
              
              
         
               
               
            }
            catch(Exception e)
            {

            }
            var result = new WeatherModel
            {
                CurrentTime = currentTime,
                Rain = rain,
                RealFeelst = realFeelst,
                CurrentTemp = currentTemp,
                RelativeHumidity = relativeHumidity,
                AirQuality = airQuality,
                Weather = weather,
                Wind = wind
            };
            return result;
        }
    }
}
