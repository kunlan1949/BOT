using BOT.Model;
using BOT.Module.Send;
using Db.Bot;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Utils.Scaffolds;
using NeteaseCloudMusicApi;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Handler.Func
{
    class SongHandler
    {
        public static async Task execAsync(Members mem, Groups g, CommandAttribute command, GroupMessageReceiver messageReceiver)
        {
            if(command.Target!=null && command.Target != "")
            {
                if (command.Params == "" || command.Params.Contains("网易云"))
                {
                    var api = new CloudMusicApi();
                    var json = await api.RequestAsync(CloudMusicApiProviders.Search, new Dictionary<string, object> { ["keywords"] = $"{command.Target}", ["limit"] = "2" });
                    if (json != null)
                    {
                        JArray res = json["result"].Value<JArray>("songs");
                        var songId = res[0].Value<string>("id");
                        var songName = res[0].Value<string>("name");
                        var singerName = res[0].Value<JArray>("artists")[0].Value<string>("name");
                        Console.WriteLine($"歌曲名：歌曲id={songId}");
                        Console.WriteLine($"歌曲名={songName}");
                        Console.WriteLine($"歌手名={singerName}");
                        var djson = await api.RequestAsync(CloudMusicApiProviders.SongDetail, new Dictionary<string, object> { ["ids"] = $"{songId}" });
                        JArray detail = djson.Value<JArray>("songs");
                        var songImg = detail[0]["al"].Value<string>("picUrl");
                        Console.WriteLine($"歌曲图Url={songImg}");

                        MessageBase[] messageBase = new MessageBase[2];
                        var path = $"http://music.163.com/song/media/outer/url?id=" + songId + "&userid=32407630";
                        var img = $"{songImg}";
                        var jump = $"http://music.163.com/song/" + songId + "/?userid=324076307";
                        messageBase = "".Append(new MusicShareMessage() { Type = Messages.MusicShare, MusicUrl = path, PictureUrl = img, Title = $"{songName}", JumpUrl = jump, Brief = $"[歌曲]{songName}", Kind = "NeteaseCloudMusic", Summary = $"歌手：[{singerName}]" });
                        await SendGroupMessageModule.sendGroupAsync(messageReceiver, messageBase);
                    }
                    else
                    {
                        await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, "未找到歌曲！请尝试其他渠道！",false);
                    }
                   
                }
            }
            else
            {
                await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, "请输入正确的歌曲名！", false);
            }
        }
    }
}
