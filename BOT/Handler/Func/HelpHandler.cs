using BOT.Helper;
using BOT.Model;
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
    class HelpHandler
    {
        public static async Task execAsync(Members mem, Groups g, CommandAttribute command, GroupMessageReceiver messageReceiver)
        {
            #region 分支目录
            if (command.Params != null)
            {
                if (command.Params != "")
                {
                    if (command.Params == "1" || command.Params.Contains("趣味游戏"))
                    {
                        await GameHelpAsync(mem, g, command, messageReceiver);
                    }
                    else if (command.Params == "2" || command.Params.Contains("插画识图"))
                    {
                        await SImageHelpAsync(mem, g, command, messageReceiver);
                    }
                    else if (command.Params == "3" || command.Params.Contains("星座运势"))
                    {
                        await LuckyAsync(mem, g, command, messageReceiver);
                    }
                    else if (command.Params == "4" || command.Params.Contains("查询天气"))
                    {
                        await WeatherAsync(mem, g, command, messageReceiver);
                    }
                    else if (command.Params == "5" || command.Params.Contains("中英互译"))
                    {
                        await TransAsync(mem, g, command, messageReceiver);
                    }
                    else if (command.Params == "6" || command.Params.Contains("游戏查询"))
                    {

                    }
                    else if (command.Params == "7" || command.Params.Contains("每日新闻"))
                    {

                    }
                    else if (command.Params == "8" || command.Params.Contains("每日签到"))
                    {

                    }
                    else if (command.Params == "11" || command.Params.Contains("猜数字"))
                    {
                        await GussNumAsync(mem, g, command, messageReceiver);
                    }
                    else if (command.Params == "12" || command.Params.Contains("猜拳"))
                    {

                    }
                    else if (command.Params == "13" || command.Params.Contains("猜字谜"))
                    {

                    }
                    else if (command.Params == "14" || command.Params.Contains("成语接龙"))
                    {

                    }
                    else
                    {
                        await SendGroupMessageModule.sendGroupAsync(messageReceiver, "错误，指令不存在，请检查后再输入!");
                    }
                }
                else
                {
                    await MainHelpAsync(mem, g, command, messageReceiver);
                }
            }
            #endregion

            #region 总帮助目录
            else
            {
                await SendGroupMessageModule.sendGroupAsync(messageReceiver, "错误，指令不正确，请检查后再输入!");
            }
            #endregion
        }

        #region 主菜单目录
        private static async Task MainHelpAsync(Members mem, Groups g, CommandAttribute command, GroupMessageReceiver messageReceiver)
        {
            var botName = ConfigHelper.BName();
            var tyface = new FaceMessage() { FaceId = "74", Type = Messages.Face };
            MessageBase[] msg = { };
            msg = $"    AI功能菜单".Append(tyface)
                .Append("KK倾力开发")
                .Append("\n").Append(
                "【1】趣味游戏【2】插画识图 \n" +
                "【3】星座运势【4】查询天气 \n" +
                "【5】中英互译【6】游戏查询 \n" +
                "【7】每日新闻【8】每日签到 \n" +
                "【9】敬请期待【0】身份注册 \n" +
                $"使用如：{botName} 帮助 1，\n" +
                $"或：{botName} 帮助 趣味游戏，注意单空格\n" +
                $"PS:使用所有功能前需要完成注册！\n");

            await SendGroupMessageModule.sendGroupAsync(messageReceiver, msg);
        }
        #endregion

        #region 游戏帮助
        private static async Task GameHelpAsync(Members mem, Groups g, CommandAttribute command, GroupMessageReceiver messageReceiver)
        {
            var botName = ConfigHelper.BName();
            var tyface = new FaceMessage() { FaceId = "74", Type = Messages.Face };
            MessageBase[] msg = { };
            msg = $"    趣味游戏目录"
                .Append("\n").Append(
                "【11】猜数字【12】猜拳 \n" +
                "【13】猜字谜【14】成语接龙 \n" +
                $"使用如：{botName} 帮助 11，\n" +
                $"或：{botName} 帮助 猜数字，注意单空格\n");

            await SendGroupMessageModule.sendGroupAsync(messageReceiver, msg);
        }
        #endregion

        #region 猜数字帮助
        private static async Task GussNumAsync(Members mem, Groups g, CommandAttribute command, GroupMessageReceiver messageReceiver)
        {
            var botName = ConfigHelper.BName();
            var zqface = new FaceMessage() { FaceId = "57", Type = Messages.Face };
            MessageBase[] msg = { };
            msg = "".Append(zqface).Append($"猜数字").Append(zqface)
                .Append("【注意单空格】\n").Append(
                $"[开局指令]：{botName} 猜数字\n" +
                $"[回答指令]：我猜 1234\n" +
                $"[结束指令]：{botName} 结束 猜数字\n" +
                $"单群内仅限开启一局，不可多开\n" +
                $"开局消耗20积分，结束需发起者或管理者\n" +
                $"回答正确加200积分，若是发起者则翻倍\n" +
                $"所有成员共享10次回答机会\n" +
                $"A代表数字存在且位置准确\n" +
                $"B代表数字存在但位置错误\n" +
                $"如：猜数字1234，你猜1324\n" +
                $"则回馈值为2A2B\n" +
                $"著名的逻辑游戏，开动大脑吧！");

            await SendGroupMessageModule.sendGroupAsync(messageReceiver, msg);
        }
        #endregion

        #region 识图帮助
        private static async Task SImageHelpAsync(Members mem, Groups g, CommandAttribute command, GroupMessageReceiver messageReceiver)
        {
            var botName = ConfigHelper.BName();
            var tyface = new FaceMessage() { FaceId = "74", Type = Messages.Face };
            MessageBase[] msg = { };
            msg = "".Append(tyface).Append($"插画识图").Append(tyface)
                .Append("【注意指令间的单空格】\n").Append(
                "【服务器占用高，使用受限！】 \n" +
                "每人五次机会，隔日凌晨刷新\n" +
                "不同查询方式共享使用次数\n" +
                $"[普通查询]：{botName} 识图\n" +
                $"附带要识别的图片\n" +
                $"[模糊查询]：{botName} 识图 模糊\n" +
                $"附带要识别的图片\n" +
                $"【图片和指令在同一条消息中】\n" +
                $"图片需完整清晰，否则识别度极低\n");

            await SendGroupMessageModule.sendGroupAsync(messageReceiver, msg);
        }
        #endregion

        #region 运势帮助
        private static async Task LuckyAsync(Members mem, Groups g, CommandAttribute command, GroupMessageReceiver messageReceiver)
        {
            var xhxface = new FaceMessage() { FaceId = "184", Type = Messages.Face };
            MessageBase[] msg = { };
            msg = "".Append(xhxface).Append($"星座运势").Append(xhxface)
                .Append("【注意单空格】\n").Append(
                $"[指令]：运势 双鱼\n" +
                $"PS：摩羯(jie)不是魔蝎！\n" +
                $"总共十二个星座！不是十二生肖!\n" + 
                $"运势不代表命运所指！\n" +
                $"娱乐为主，请勿轻信！\n" +
                $"生而为人，祝你好运！");

            await SendGroupMessageModule.sendGroupAsync(messageReceiver, msg);
        }
        #endregion

        #region 翻译帮助
        private static async Task TransAsync(Members mem, Groups g, CommandAttribute command, GroupMessageReceiver messageReceiver)
        {
            var kuface = new FaceMessage() { FaceId = "16", Type = Messages.Face };
            MessageBase[] msg = { };
            msg = "".Append(kuface).Append($"中英互译").Append(kuface)
                .Append("【注意单空格】\n").Append(
                $"数据源来源：【有道翻译】\n" +
                $"[指令]：翻译 I love You\n" +
                $"妈妈再也不用担心我看不懂英语了！\n");

            await SendGroupMessageModule.sendGroupAsync(messageReceiver, msg);
        }
        #endregion



        #region 天气帮助
        private static async Task WeatherAsync(Members mem, Groups g, CommandAttribute command, GroupMessageReceiver messageReceiver)
        {
            var tyface = new FaceMessage() { FaceId = "74", Type = Messages.Face };
            MessageBase[] msg = { };
            msg = "".Append(tyface).Append($"查询天气").Append(tyface)
                .Append("【注意单空格】\n").Append(
                $"[指令]：天气 北京\n" +
                $"PS：没有县区查询，仅限市级单位！\n" +
                $"数据来源：中央气象台!\n" +
                $"天气无常，多多关注！\n" +
                $"你若安好，便是晴天！");

            await SendGroupMessageModule.sendGroupAsync(messageReceiver, msg);
        }
        #endregion
    }
}
