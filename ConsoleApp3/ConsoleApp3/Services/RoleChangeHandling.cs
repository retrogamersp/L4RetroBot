using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Collections.Generic;

namespace ConsoleApp3.Services
{
    public class RoleHandlingModule
    {
        private readonly DiscordSocketClient _discord;
        private readonly CommandService _commands;
        private IServiceProvider _provider;
        public static ulong messageid;
        public static ulong ID
        {
            get {return messageid;}
            set {messageid = value;}
        }

        public RoleHandlingModule(IServiceProvider provider, DiscordSocketClient discord, CommandService commands)
        {
            _discord = discord;
            _commands = commands;
            _provider = provider;
            _discord.GuildMemberUpdated += HandleRoleChangeAsync;
        }
        public async Task InitializeAsync(IServiceProvider provider)
        {
            _provider = provider;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), services: null);
            // Add additional initialization code here...
        }
        public void HandleRoleChange(BaseSocketClient client)
    => client.GuildMemberUpdated += HandleRoleChangeAsync;
        public async Task HandleRoleChangeAsync(SocketGuildUser before, SocketGuildUser after)
        {
            if (before.Roles.Count != after.Roles.Count)
            {
                ulong ID = 671665108593803264;
                var channel = _discord.GetChannel(ID) as IMessageChannel;
                List<string> rolesbefore = new List<string>();
                List<string> rolesafter = new List<string>();
                foreach (SocketRole role in before.Roles)
                {
                    rolesbefore.Add(role.Name);
                }
                foreach (SocketRole role in after.Roles)
                {
                    rolesafter.Add(role.Name);
                }
                string[] rolesbeforestring = rolesbefore.ToArray();
                string[] rolesafterstring = rolesafter.ToArray();
                var builder = new EmbedBuilder()
                    .WithDescription($"A Guild Member has been Updated\n\n**User:** {before.Username}\n\n**Change:** Roles Updated")
                    .WithColor(new Color(0x1C12A5))
                    .WithTimestamp(DateTimeOffset.FromUnixTimeMilliseconds(1580374361153))
                    .WithAuthor(author => {
                        author
                            .WithName("Guild Member Updated");
                    })
                    .AddField("**Roles Before**", $"{string.Join("\n", rolesbeforestring)}", true)
                    .AddField("Roles After", $"{string.Join("\n", rolesafterstring)}", true);
                    var embed = builder.Build();
                await channel.SendMessageAsync(embed: embed);

            }
            else if (before.Nickname != null && after.Nickname != null)
                {
                    ulong ID = 671665108593803264;
                    var channel = _discord.GetChannel(ID) as IMessageChannel;
                    var builder = new EmbedBuilder()
                        .WithDescription($"A Guild Member has been Updated\n\n**User:** {before.Username}\n\n**Change:** Nickname Updated")
                        .WithColor(new Color(0x1C12A5))
                        .WithTimestamp(DateTimeOffset.FromUnixTimeMilliseconds(1580374361153))
                        .WithAuthor(author => {
                            author
                                .WithName("Guild Member Updated");
                        })
                        .AddField("**Nickname Before**", $"{before.Nickname}", true)
                        .AddField("**Nickname After**", $"{after.Nickname}", true);
                    var embed = builder.Build();
                    await channel.SendMessageAsync(embed: embed);
                }
                else if (before.Nickname == null)
                {
                    ulong ID = 671665108593803264;
                    var channel = _discord.GetChannel(ID) as IMessageChannel;
                    var builder = new EmbedBuilder()
                        .WithDescription($"A Guild Member has been Updated\n\n**User:** {before.Username}\n\n**Change:** Nickname Updated")
                        .WithColor(new Color(0x1C12A5))
                        .WithTimestamp(DateTimeOffset.FromUnixTimeMilliseconds(1580374361153))
                        .WithAuthor(author => {
                            author
                                .WithName("Guild Member Updated");
                        })
                        .AddField("**Nickname Before**", $"{before.Username}", true)
                        .AddField("**Nickname After**", $"{after.Nickname}", true);
                    var embed = builder.Build();
                    await channel.SendMessageAsync(embed: embed);
                }
                else if (after.Nickname == null)
                {
                    ulong ID = 671665108593803264;
                    var channel = _discord.GetChannel(ID) as IMessageChannel;
                    var builder = new EmbedBuilder()
                        .WithDescription($"A Guild Member has been Updated\n\n**User:** {before.Username}\n\n**Change:** Nickname Updated")
                        .WithColor(new Color(0x1C12A5))
                        .WithTimestamp(DateTimeOffset.FromUnixTimeMilliseconds(1580374361153))
                        .WithAuthor(author => {
                            author
                                .WithName("Guild Member Updated");
                        })
                        .AddField("**Nickname Before**", $"{before.Nickname}", true)
                        .AddField("**Nickname After**", $"{after.Username}", true);
                    var embed = builder.Build();
                    await channel.SendMessageAsync(embed: embed);
                }
               
            }
            

        }

    }
