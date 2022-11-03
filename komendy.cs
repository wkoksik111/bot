using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Discord.Interactions;
using Discord.Net;
using Discord.API;
using Discord.Webhook;
using Discord.Audio;
using Discord.Rest;
using System.Windows.Forms;

namespace bot.moduly
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("!powiedz")]
        public async Task powiedz([Remainder] string tekst)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"[Command] | {Context.Guild} : {Context.User} : used !powiedz");
            var wiadomosc = await this.ReplyAsync($"powtarzam po {Context.User} : {tekst}");
        }
        [Command("!avatar")]
        public async Task avatar()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            var user = Context.User;
            var embed = new EmbedBuilder()
                .WithAuthor(user)
                .WithColor(Color.Purple)
                .WithFooter("WOmodLiteV2")
                .WithImageUrl(user.GetAvatarUrl())
                .Build();

            await this.ReplyAsync(embed: embed);
            Console.WriteLine($"[Command] | {Context.Guild} : {Context.User} : used !avatar");
        }
        [Command("!join")]
        public async Task JoinChannel(IVoiceChannel channel = null)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            channel = channel ?? (Context.User as IGuildUser)?.VoiceChannel;
            if (channel == null) { await Context.Channel.SendMessageAsync("User must be in a voice channel, or a voice channel must be passed as an argument."); return; }

            var audioClient = await channel.ConnectAsync();
            Console.WriteLine($"[Command] | {Context.Guild} : {Context.User} : used !join");
        }
        [Command("!iq")]
        public async Task iq()
        {
            Random gen = new Random();
            int iq = gen.Next(-100, 200);
            Console.ForegroundColor = ConsoleColor.Cyan;
            var embed = new EmbedBuilder()
                .WithTitle("IQ " + Context.User)
                .WithColor(Color.DarkPurple)
                .WithDescription($"**masz `{iq}` iq {Context.User}**")
                .WithThumbnailUrl(Context.User.GetAvatarUrl())
                .WithFooter("WOmodLiteV2//IQ")
                .Build();

            var embem = await this.ReplyAsync(embed: embed);
            Console.WriteLine($"[Command] | {Context.Guild} : {Context.User} : used !iq");
        }
        [Command("!embed")]
        public async Task EmbdeAsync(string title = null, [Remainder] string description = null)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            var embed = new EmbedBuilder()
                .WithTitle(title)
                .WithColor(Color.Purple)
                .WithDescription(description)
                .WithFooter("WOmodLiteV2//EmbedCreator")
                .Build();

            var embem = await this.ReplyAsync(embed: embed);
            Console.WriteLine($"[Command] | {Context.Guild} : {Context.User} : used !embed");
        }
    }
}
