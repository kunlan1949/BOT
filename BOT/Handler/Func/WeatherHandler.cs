using BookServer.NodeParse.Weather;
using BookServer.NodeParse.Weather.jsonmodel;
using BOT.Model;
using BOT.Module.Send;
using BOT.Utils;
using Db.Bot;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Utils.Scaffolds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Handler.Func
{
    class WeatherHandler
    {
        public static async Task execAsync(Members mem, Groups g, CommandAttribute command, GroupMessageReceiver messageReceiver)
        {
            if(command.Target != null && command.Target != "")
            {
                var city = Citys.Find(Citys._.CityName == command.Target);
                if (city != null)
                {
                    var result = WeatherParse.WeatherResult(city.CityCode);
                    await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, $"更新时间[{result.CurrentTime}]\n".Append($"{city.CityName} 今天{result.Weather}\n当前气温 {result.CurrentTemp}℃\n体感温度 {result.RealFeelst}℃ \n空气质量为：【{WeatherUtil.AirQuality(result.AirQuality)}】{result.AirQuality}\n{result.Wind.WindDirect} ：{result.Wind.WindSpeed}"), true);
                }
                else
                {
                    await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, "未找到相关城市信息!",true);
                }

            }
        }
    }
}
