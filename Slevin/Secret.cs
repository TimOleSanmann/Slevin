using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Slevin
{
    public class Secret
    {
        public static string GetToken()
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var secret = config.GetSection("DiscordBotToken").Value;
            return secret;
        }
    }
}
