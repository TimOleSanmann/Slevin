using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord.Commands;
using Discord;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Slevin
{
    public class Botmanager
    {
        public DiscordSocketClient BotClient;
        public CommandService CommandService;
        public IServiceProvider ServiceProvider;
        public const string PREFIX = "!slevin";

        public async Task RunBot()
        {
            CommandService = new CommandService();
            ServiceProvider = ConfigureServices();
            BotClient = new DiscordSocketClient();
            await BotClient.LoginAsync(Discord.TokenType.Bot, ConfigManager.GetBotToken());
            await BotClient.StartAsync();

            BotClient.Log += Log;
            BotClient.Ready += Ready;

            await Task.Delay(-1);
        }

        private async Task Ready()
        {
            await CommandService.AddModulesAsync(Assembly.GetEntryAssembly(), ServiceProvider);
            await BotClient.SetGameAsync("Is playing a game");
            BotClient.MessageReceived += ReceiveMessage;
        }

        private async Task ReceiveMessage(SocketMessage arg)
        {
            SocketUserMessage message = arg as SocketUserMessage;
            int commandPosition = 0;
            if (message.HasStringPrefix(PREFIX, ref commandPosition))
            {
                commandPosition = PREFIX.Length + 1;
                SocketCommandContext context = new SocketCommandContext(BotClient, message);
                IResult result = await CommandService.ExecuteAsync(context, commandPosition, ServiceProvider);
                if (!result.IsSuccess)
                {
                    Console.WriteLine(result.ErrorReason);
                }
            }
        }

        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        public IServiceProvider ConfigureServices()
        {
            return new ServiceCollection().AddSingleton<Commands>().BuildServiceProvider();
        }
    }
}
