using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Slevin
{
    public class ConfigManager
    {
        private const string ConfigName = "appsettings.json";
        private static IConfigurationRoot config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(ConfigName).Build();
        public static string GetBotToken()
        {
            return config.GetSection("DiscordBotToken").Value;
        }

        public static string GetDatabasePath()
        {
            return config.GetSection("DatabasePath").Value;
        }
    }
}
