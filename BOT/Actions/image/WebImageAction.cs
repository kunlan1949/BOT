using BOT.Model;
using BOT.Module.Send;
using Mirai.Net.Data.Messages.Receivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BOT.Actions.image
{
    class WebImageAction
    {
        public static async Task TestAsync(CommandAttribute command, FriendMessageReceiver messageReceiver, bool exec)
        {
            if(command.Target!=null && command.Target != "")
            {
                if (command.Target.Contains("截图"))
                {
                    createImg();
                    await SendFriendMessageModule.sendFriendAsync(messageReceiver, "截图完成！");
                }
                else
                {
                    await SendFriendMessageModule.sendFriendAsync(messageReceiver, "指令错误！");
                }
            }
        }


        private static void createImg()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Size = new Size(750, 2355);
            string URL = "file:///" + HttpUtility.UrlEncode(@$"{AppDomain.CurrentDomain.BaseDirectory}poster\index.html");
            driver.Navigate().GoToUrl(URL);
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(@$"{AppDomain.CurrentDomain.BaseDirectory}\Res\sss.png", ScreenshotImageFormat.Png);
            driver.Close();
            driver.Dispose();
        }


        private static string createHtml()
        {
            string temp = "<!DOCTYPEhtml><html><head><metacharset='utf-8'><title>菜鸟教程(runoob.com)</title><linkrel='stylesheet'type='text/css'href='http://iomoi.top:8092/css/style.css'/></head>" +
                "<body>" +
                "<divid='bg'>" +
                "<divid='mainpage'>" +
                "<divclass='tieleBox'>" +
                "<divid='title1'>" +
                "<span>每日简讯</span>" +
                "</div><divid='titleSplit'><imgsrc='http://iomoi.top:8092/img/split.png'/></div>" +
                "<divid='titleimg'><imgsrc='http://iomoi.top:8092/img/headline.png'/></div></div>" +
                "<divid='middleBox'><divid='middleImg'><imgsrc='http://iomoi.top:8092/img/middleImage.png'/></div><divid='middleTitle'><span>每天都有新气象</span></div>" +
                "<divid='middleDate'><span>2021年9月10日</span></div>" +
                "<divid='middleWeek'><span>星期五第37周</span></div>" +
                "<divid='middleNYear'><span>牛年八月初四</span></div>" +
                "<divid='middleZWYear'><span>辛丑年丁酉月辛酉日</span></div>" +
                "<divid='middleGood'><span>宜：祭祀祈福求嗣出行沐浴</span></div>" +
                "<divid='middleBad'><span>忌：动土作灶行丧安葬修坟</span></div></div>" +
                "<divid='contentBox'><divid='contentBG'></div></div></div></div></body></html>";

            return "";
        }
    }
    
}
