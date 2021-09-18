using Db.Bot;
using Microsoft.Extensions.Configuration;
using SharedLibrary.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Helper
{
    class ConfigHelper
    {
        private static IConfiguration _configuration;

        static ConfigHelper()
        {
            //在当前目录或者根目录中寻找config.json文件
            var fileName = "config.json";

            var directory = AppDomain.CurrentDomain.BaseDirectory;
            directory = directory.Replace("\\", "/");

            var filePath = $"{directory}{fileName}";
            if (!File.Exists(filePath))
            {
                var length = directory.IndexOf("/bin");
                filePath = $"{directory.Substring(0, length)}/{fileName}";
            }


            var builder = new ConfigurationBuilder()
                .AddJsonFile(filePath, false, true);


            _configuration = builder.Build();
        }
        //获取值
        public static string GetSectionValue(string key)
        {
            return _configuration.GetSection(key).Value;
        }

        public static string[] GetSectionValues(string key)
        {
            return _configuration.GetSection(key).Get<string[]>();
        }

        public static string GRoleName()
        {
            var name = "角色祈愿";
            var builder = new ConfigurationBuilder();
            builder.AddXmlFile("setting.config", optional: true, reloadOnChange: true);

            var configuration = builder.Build();

            name = configuration.GetSection("GenshinRoleUpName:value").Value;
            return name;
        }

        public static string BName()
        {
            var builder = new ConfigurationBuilder();
            builder.AddXmlFile("setting.config", optional: true, reloadOnChange: true);

            var configuration = builder.Build();

            var BotName = configuration.GetSection("BotName:value").Value;

            return BotName;
        }

        public static ConfigModel GetInfo()
        {
            var builder = new ConfigurationBuilder();
            builder.AddXmlFile("setting.config", optional: true, reloadOnChange: true);

            var configuration = builder.Build();

            var Number = configuration.GetSection("Number:value").Value;
            var VerifyKey = configuration.GetSection("VerifyKey:value").Value;
            var Address = configuration.GetSection("Address:value").Value;
            if (Number == null || VerifyKey == null || Address == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("配置文件异常，请检查配置文件格式后重试");
                Console.ResetColor();
                Environment.Exit(0);
            }

            var configModel = new ConfigModel()
            {
                Number = Number,
                VerifyKey = VerifyKey,
                Address = Address
            };
            return configModel;
        }


    }

}
