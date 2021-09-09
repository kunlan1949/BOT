using BOT.Actions.steam;
using BOT.Model;
using BOT.Model.Func;
using BOT.Module.Send;
using Db.Bot;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Utils.Scaffolds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Handler.Func
{
    class SteamHandler
    {
        public static async Task execAsync(Members mem, Groups g, CommandAttribute command, GroupMessageReceiver messageReceiver)
        {
            if(command.Target!=null && command.Target != "")
            {
                await SendGroupMessageModule.sendGroupAsync(messageReceiver, "查询需要10S左右，请稍等");
                var value = new SteamInfoModel();
                await SteamSearchAction.GetValueAsync(command.Target).ContinueWith(async (e)=> {
                    value = e.Result;

                    MessageBase[] commonMsg = { };

                    MessageBase[] priceMsg = { };

                    if (!value.GamePrice.Contains("-1"))
                    {
                        priceMsg = "".Append(
                        $"游戏价格：{value.GamePrice}\n");
                    }
                    else
                    {
                        priceMsg = $"【该游戏{value.GameDcPercent}折扣中!】\n".Append(
                        $"游戏原价：{value.GameBdcPrice}\n" +
                        $"游戏现价：{value.GameDcPrice}\n");
                    }


                    commonMsg = "【图片显示暂时受限！】\n"//.Append(new ImageMessage() { Url = value.GameImgUrl,Type = Messages.Image})
                    .Append(
                        $"游戏ID：{value.GameId}\n" +
                        $"游戏名：{value.GameName}\n" +
                        $"链接：：{value.GameUrl}\n" +
                        $"在线人数：{value.GameOnline}\n" +
                        $"评价等级：[{value.GameEvaStatus}]\n" +
                        $"评价人数：[{value.GameEvaCount}]\n" +
                        $"游戏简介：{value.GameDesc}\n").Append(priceMsg);

                   
                    await SendGroupMessageModule.sendGroupAtAsync(messageReceiver,commonMsg, true);
                });
                
            }
            else
            {

            }
        }
    }
}
