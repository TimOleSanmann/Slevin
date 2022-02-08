using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord.Commands;
using Discord;

namespace Slevin
{
    public class Botmanager
    {
        public DiscordSocketClient BotClient;
        public CommandService CommandService;
        public IServiceProvider ServiceProvider;
        public const string PREFIX = "!";

        public async Task RunBot()
        {
            CommandService = new CommandService();
            ServiceProvider = ConfigureServices();
            BotClient = new DiscordSocketClient();
            await BotClient.LoginAsync(Discord.TokenType.Bot, Secret.GetToken());
            await BotClient.StartAsync();

            BotClient.Log += Log;

            await Task.Delay(-1);
        }

        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        public IServiceProvider ConfigureServices()
        {
            return null;
        }
    }
}
