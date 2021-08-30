using Microsoft.Extensions.Configuration;
using SharedLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Helper
{
    class ConfigHelper
    {
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
