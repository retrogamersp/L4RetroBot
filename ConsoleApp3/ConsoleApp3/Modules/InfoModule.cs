using System;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using ConsoleApp3.Services;
using ConsoleApp3;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using ConsoleApp3.Models;

namespace ConsoleApp3.Modules
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        [Command("info")]   
        [Summary("Displays Bot Info")]
        
        public async Task Info()
        {
            
            Discord.IUser U = Context.Message.Author;

            string msg = "**Bot Info**\nTest";
            await Discord.UserExtensions.SendMessageAsync(U, msg);
            
            await Context.Message.DeleteAsync();
        }


    }
    public class AvatarModule : ModuleBase<SocketCommandContext>
    {
        [Command("avatar")]
        [Summary("Fetches Command Users Avatar")]

        public async Task Info()
        {

            Discord.IUser U = Context.Message.Author;
            string imgurl = U.AvatarId;
            string userurl = U.Id.ToString();
            string AvatartoEmbed = $"https://cdn.discordapp.com/avatars/{userurl}/{imgurl}.webp?size=1024";
            Random rnd = new Random();
            int red = rnd.Next(0, 255);
            int green = rnd.Next(0, 255);
            int blue = rnd.Next(0, 255);
            var EmbedAuth = new EmbedAuthorBuilder
            {
                Name = U.ToString(),
                
            };

            var EmbedFoot = new EmbedFooterBuilder
            {
                IconUrl = "https://cdn.discordapp.com/embed/avatars/0.png",
                Text = $"Generated - {DateTime.UtcNow.ToLongDateString()}",
            };

            var EmbedBuilder = new EmbedBuilder
            {
                Title = "Profile Picture",
                Author = EmbedAuth,
                ImageUrl = AvatartoEmbed,
                Footer = EmbedFoot,
                Url = AvatartoEmbed,
                Color = new Discord.Color(red, green, blue),

            
                
               
            }.Build();

            await Discord.UserExtensions.SendMessageAsync(U, embed: EmbedBuilder);


            await Context.Message.DeleteAsync();
        }


    }
    public class GetAvatarModule : ModuleBase<SocketCommandContext>
    {
        [Command("getavatar")]
        [Summary("Displays Bot Info")]

        public async Task Info(Discord.IUser user)
        {

            Discord.IUser U = user;
            Discord.IUser E = Context.Message.Author;
            string imgurl = U.AvatarId;
            string userurl = U.Id.ToString();
            string AvatartoEmbed = $"https://cdn.discordapp.com/avatars/{userurl}/{imgurl}.webp?size=1024";
            Random rnd = new Random();
            int red = rnd.Next(0, 255);
            int green = rnd.Next(0, 255);
            int blue = rnd.Next(0, 255);
            var EmbedAuth = new EmbedAuthorBuilder
            {
                Name = U.ToString(),

            };

            var EmbedFoot = new EmbedFooterBuilder
            {
                IconUrl = "https://cdn.discordapp.com/embed/avatars/0.png",
                Text = $"Generated - {DateTime.UtcNow.ToLongDateString()}",
            };

            var EmbedBuilder = new EmbedBuilder
            {
                Title = "Profile Picture",
                Author = EmbedAuth,
                ImageUrl = AvatartoEmbed,
                Footer = EmbedFoot,
                Url = AvatartoEmbed,
                Color = new Discord.Color(red, green, blue),




            }.Build();

            await Discord.UserExtensions.SendMessageAsync(E, embed: EmbedBuilder);


            await Context.Message.DeleteAsync();
        }


    }
    public class KickModule : ModuleBase<SocketCommandContext>
    {
        [Command("kick"), RequireUserPermission(GuildPermission.KickMembers)]
        [Summary("Displays Bot Info")]

        public async Task Info(IGuildUser user, string reason)
        {

            Discord.IUser E = Context.Message.Author;
            if (user.Username.ToString() == E.Username.ToString())
            {
                await Context.Channel.SendMessageAsync("You cannot use this command on yourself");
            }
            else if (user.Username.ToString() != E.Username.ToString())
            {
                var _client = Context.Client;
                string imgurl = user.AvatarId;
                string userurl = user.Id.ToString();
                string AvatartoEmbed = $"https://cdn.discordapp.com/avatars/{userurl}/{imgurl}.webp?size=1024";
                string PunishmentType = "Kick";
                ulong ID = 671665108593803264;
                var channel = _client.GetChannel(ID) as IMessageChannel;
                var EmbedAuth = new EmbedAuthorBuilder
                {
                    Name = user.ToString(),

                };

                var builder = new EmbedBuilder()
                    .WithTitle($"Punishment Type: {PunishmentType}")
                    .WithDescription($"Punished User: {user.Username.ToString()}")
                    .WithUrl("https://discordapp.com")
                    .WithTimestamp(DateTimeOffset.FromUnixTimeMilliseconds(1580207925966))
                    .WithFooter(footer =>
                    {
                        footer
                            .WithText("Punished On");
                    })
                    .WithImageUrl(AvatartoEmbed)
                    .WithAuthor(author =>
                    {
                        author
                            .WithName("Punishment Log")
                            .WithUrl("https://discordapp.com")
                            .WithIconUrl("https://cdn.discordapp.com/embed/avatars/0.png");
                    })
                    .AddField("Reason:", reason)
                    .AddField("Punishment Length", "N/A - Kick")
                    .AddField("Punished By", E)
                    .WithColor(new Discord.Color(255, 0, 0));
                var embed = builder.Build();
                await channel.SendMessageAsync(embed: embed);
                await Discord.UserExtensions.SendMessageAsync(user, $"You were kicked from {Context.Guild.Name} for {reason}");
                await user.KickAsync(reason);
            } 
            else
            {
                await Context.Channel.SendMessageAsync("You dont have enough permissions to do that command");
            }
            await Context.Message.DeleteAsync();
        }


    }
    public class ReactionModule : ModuleBase<SocketCommandContext>
    {
        [Command("reactionsetup"), RequireUserPermission(GuildPermission.Administrator)]
        [Summary("Sets up Role Picker")]

        public async Task Info()
        {
            var _client = Context.Client;
            ulong ID = 672009794147581953;
            var channel = _client.GetChannel(ID) as IMessageChannel;
            Discord.IUser U = Context.Message.Author;
            IEmote[] emotes1 = new IEmote[] {Emote.Parse("<:Unreal:672062790499827721>"), Emote.Parse("<:Unity:672063190535766026>"), Emote.Parse("<:3DSMax:672063870776508418>"), Emote.Parse("<:Blender:672063714572107786>") };
            var roleEmbedAuth = new EmbedAuthorBuilder

            {
                Name = U.ToString(),

            };

            var rolebuilder = new EmbedBuilder()
                .WithTitle("React to gain a role.")
                .WithDescription($"Select a reaction to gain a role.\n\n{Emote.Parse("<:Unreal:672062790499827721>")} - Unreal Development\n\n <:Unity:672063190535766026> - Unity Development\n\n <:3DSMax:672063870776508418> - 3DSMax Modelling\n\n <:Blender:672063714572107786> - Blender Moddeling")
                .WithUrl("https://discordapp.com")
                .WithAuthor(author => {
                    author
                        .WithName("Role Giver")
                        .WithUrl("https://discordapp.com");
                });
            var roleembed = rolebuilder.Build();
            var rolemessage = await channel.SendMessageAsync(embed: roleembed);
            await rolemessage.AddReactionsAsync(emotes1);
            var emoji = new Emoji("\uD83C\uDFAB");
            var ticketEmbedAuth = new EmbedAuthorBuilder

            {
                Name = U.ToString(),

            };

            var ticketbuilder = new EmbedBuilder()
                .WithTitle("React to open a support ticket.")
                .WithDescription($"React with {emoji} to open a support ticket")
                .WithUrl("https://discordapp.com")
                .WithAuthor(author => {
                    author
                        .WithName("Support Ticket Creator")
                        .WithUrl("https://discordapp.com");
                });
            var ticketembed = ticketbuilder.Build();
            var ticketmessage = await channel.SendMessageAsync(embed: ticketembed);
            await ticketmessage.AddReactionAsync(emoji);

            await Context.Message.DeleteAsync();
        }


    }
    public class CloseTicketModule : ModuleBase<SocketCommandContext>
    {
        [Command("closeticket")]
        [Summary("Sets up Role Picker")]

        public async Task Info()
        {
            var _client = Context.Client;
            ulong ID = 672390262877716480;
            var channel = _client.GetChannel(ID) as IMessageChannel;
            var emoji = new Emoji("\u274C");
            Discord.IUser U = Context.Message.Author;
            if ((Context.Channel as SocketTextChannel).CategoryId == 672377248065781760)
            {
                await channel.SendMessageAsync($"{emoji} - {Context.Message.Author} has closed the Support Ticket for {Context.Channel.Name}");
                await (Context.Channel as SocketTextChannel).DeleteAsync();
            }
            else
                await Context.Message.DeleteAsync();
        }


    }
    public class BotAvatarModule : ModuleBase<SocketCommandContext>
    {
        [Command("botavatar"), RequireUserPermission(GuildPermission.Administrator)]
        [Summary("Sets the bots avatar")]

        public async Task Info(string url)
        {
            {
                using (System.Net.WebClient webClient = new System.Net.WebClient())
                {
                    using (Stream stream = webClient.OpenRead(url))
                    {
                        var image = new Discord.Image(stream);
                        await Context.Client.CurrentUser.ModifyAsync(u => u.Avatar = image);
                    }
                }
            }
        }


    }
    public class OWStatsModule : ModuleBase<SocketCommandContext>
    {
        [Command("OWStats")]
        [Summary("Sets the bots avatar")]

        public async Task Info(string platform = null, string region = null, string battletag = null, string hero = null)
        {
            if (platform == null || region == null || battletag == null)
            {
                await Context.Channel.SendMessageAsync("Command Missing required parameters, correct usage is !owstats (platform) (region) (battletag) <hero>");
            }
            else
            {
                string battletagformatted = battletag.Replace("#", "-");
                if (hero == null)
                {
                    owstatsmodel stats = null;
                    string URL = $"https://ow-api.com/v1/stats/{platform}/{region}/{battletagformatted}/profile";
                    HttpClient client = new HttpClient();
                    HttpResponseMessage response = await client.GetAsync(URL);
                    if (response.IsSuccessStatusCode)
                    {
                        stats = await response.Content.ReadAsAsync<owstatsmodel>();
                    }
                    else
                    {

                        Console.WriteLine(response);
                        Console.WriteLine(URL);
                    }
                }
            }
        }
            

    }


}



