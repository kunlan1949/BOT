using BOT.Actions.SearchImage;
using BOT.Helper;
using BOT.Model;
using BOT.Module.Send;
using BOT.Utils;
using Db.Bot;
using IqdbApi;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Utils.Scaffolds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BOT.Model.TypeHelper;

namespace BOT.Handler.Func
{
    class SImageHandler
    {


        public static async Task exeAsync(Members mem, Groups g, CommandAttribute command, GroupMessageReceiver messageReceiver)
        {
            if (mem.MemLimit > 5)
            {
                var mission = MissionHelper.missionExist(mem.MissionId);
                if (mission == null)
                {
                    if (!UtilHelper.ISTODAY(mem.ImgTime))
                    {
                        mem.SimageLimit = 5;
                        mem.ImgTime = UtilHelper.GetTimeUnix().ToString();
                        mem.Update();
                    }
                    if (mem.SimageLimit > 0)
                    {
                        //if (mem.SImg == 0)
                        //{
                        if (command.Params != null && command.Params != "")
                        {

                            if (command.Params.Contains("模糊"))
                            {
                                MissionHelper.createMission(mem, messageReceiver, (int)MissionType.SIMAGE, 1);
                                //修改数据库
                                memSetDB(mem, true);
                                await exeMutliAsync(mem,messageReceiver);
                                
                            }
                            else
                            {
                                MissionHelper.createMission(mem, messageReceiver, (int)MissionType.SIMAGE, 0);
                                memSetDB(mem, true);
                                await exeDefaultAsync(mem, messageReceiver);
                            }
                        }
                        else
                        {
                            MissionHelper.createMission(mem, messageReceiver, (int)MissionType.SIMAGE, 0);
                            memSetDB(mem, true);
                            await exeDefaultAsync(mem, messageReceiver);
                        }
                        //}
                        //else
                        //{
                        //    await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, "已存在识图任务！请等待完成后再次使用！", false);
                        //}
                    }
                    else
                    {
                        await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, "您今日的识图次数已经用完！", false);
                    }
                }
                else
                {
                    var mType = MissionUtil.getType(mission.MType, mission.MTypeAux);
                    await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, $"您存在一个未完成任务！任务种类：{mType}", true);
                }

            }
            else
            {
                await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, "您没有使用此功能的权限！", false);
            }


        }

        public static async Task exeAsync(Members mem, GroupMessageReceiver messageReceiver, int type)
        {
            switch (type)
            {
                case 0: 
                    {
                        await exeDefaultAsync(mem, messageReceiver);
                        break; 
                    }
                case 1:
                    {
                        await exeMutliAsync(mem, messageReceiver);
                        break;
                    }
            }
        }


        private static async Task exeDefaultAsync(Members mem, GroupMessageReceiver messageReceiver)
        {
            var image = messageReceiver.MessageChain.WhereAndCast<ImageMessage>();
            if (image != null)
            {
                if (image.Length > 0)
                {

                    await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, "识图需要时间，请耐心等待！", false);
                    Console.WriteLine($"要查找的图片链接：【{image[0].Url}】+【{image[0].Base64}】");
                    MessageBase[] msg = { };

                    await SearchImageAction.imgAsync(image[0].Url).ContinueWith(async (e) =>
                    {
                        var imageInfoList = e.Result;
                        if (imageInfoList != null)
                        {
                            var loca = imgLocationTrans(imageInfoList.First().ImageLocation);
                            msg = "".Append("识图信息来源：【ASCII2D】\n")
                            .Append(new ImageMessage() { Url = imageInfoList.First().PreImageUrl, Type = Messages.Image })
                            .Append($"作者:{imageInfoList.First().AuthorName}\n")
                            .Append($"作者链接:{imageInfoList.First().ImageAuthorUrl}\n")
                            .Append($"作品名:{imageInfoList.First().ImageName}\n")
                            .Append($"作品详情链接:{imageInfoList.First().DetailUrl}\n")
                            .Append($"出处:{loca}\n")
                            .Append($"作品有可能同时出现在Pixiv和Twitter上，\n本查询优先展示Twitter\n")
                            .Append($"您的本日查询次数剩余 {mem.SimageLimit} 次\n次数会在每日凌晨更新!\n");
                            await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, msg, false);
                            MissionHelper.endMission(mem, mem.MissionId);
                            //修改数据库
                            memSetDB(mem, false);
                        }
                        else
                        {
                            await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, "图片未能找到对应结果，请使用模糊查询", false);
                            MissionHelper.endMission(mem, mem.MissionId);
                            //修改数据库
                            memSetDB(mem, false);
                        }
                    });
                }
                else
                {
                    await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, "请发送您想要查找的图片!", false);
                }

            }

        }
        /// <summary>
        /// Saucenao识图
        /// </summary>
        /// <param name="mem"></param>
        /// <param name="g"></param>
        /// <param name="command"></param>
        /// <param name="messageReceiver"></param>
        /// <returns></returns>
        private static async Task exeSAUAsync(Members mem, Groups g, CommandAttribute command, GroupMessageReceiver messageReceiver)
        {

        }
        /// <summary>
        /// IQDB识图
        /// </summary>
        /// <param name="mem"></param>
        /// <param name="g"></param>
        /// <param name="command"></param>
        /// <param name="messageReceiver"></param>
        /// <returns></returns>
        private static async Task exeMutliAsync(Members mem, GroupMessageReceiver messageReceiver)
        {
            IIqdbClient api = new IqdbClient();
            var image = messageReceiver.MessageChain.WhereAndCast<ImageMessage>();

            if (image.Length > 0)
            {
                await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, "模糊查询开始，识别需要时间，请耐心等待！", false);
                MessageBase[] msg = { };
                var results = await api.SearchUrl($"{image[0].Url}");
                var url = "https://iqdb.org/" + results.Matches[0].PreviewUrl;
                Console.WriteLine(url);
                var loca = imgLocationTrans(results.Matches[0].Source.ToString());
                msg = "".Append("识图信息来源：【IQDB】\n")
                .Append(new ImageMessage() { Url = url, Type = Messages.Image })
                .Append($"作品详情链接:{results.Matches[0].Url}\n")
                .Append($"出处:{loca}\n")
                .Append($"准确度：{results.Matches[0].Similarity}%\n【大于90%匹配度高,具体以缩略图为准】\n")
                .Append($"您的本日查询次数剩余 {mem.SimageLimit} 次\n次数会在每日凌晨更新!\n");
                await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, msg, false);
                MissionHelper.endMission(mem, mem.MissionId);
                //修改数据库
                memSetDB(mem, false);
            }
            
            else
            {
                await SendGroupMessageModule.sendGroupAtAsync(messageReceiver, "请发送您想要查找的图片!", false);
            }

        }



        private static void memSetDB(Members members, bool onoff)
        {
            if (onoff)
            {

                var sCount = members.SimageLimit;
                var dCount = 0;
                dCount = sCount - 1;
                if (dCount == 0)
                {
                    members.ImgTime = UtilHelper.GetTimeUnix().ToString();
                }
                members.SimageLimit = dCount;

                members.Update();
            }
            else
            {
                members.Update();
            }

        }


        private static string imgLocationTrans(string location)
        {
            string str = location.Replace("\"", "");
            string lo = "";
            if (str.Contains("pixiv"))
            {
                lo = $"{UtilHelper.ConvertFirstUpper(lo)}";
            }
            else if (str.Contains("twitter"))
            {
                lo = $"{UtilHelper.ConvertFirstUpper(lo)}";
            }
            else
            {
                lo = str;
            }

            return lo;
        }
    }
}
