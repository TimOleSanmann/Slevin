using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slevin
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("info")]
        public async Task info()
        {
            var embed = new EmbedBuilder
            {
                Title = "Information",
                Description = "I am Slevin"
            };

            embed.WithUrl("https://github.com/TimOleSanmann/Slevin");

            await ReplyAsync(embed: embed.Build());
        }
    }
}
