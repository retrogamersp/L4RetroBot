using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace ConsoleApp3.Services
{
    public class ReactionHandlingModule
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

        public ReactionHandlingModule(IServiceProvider provider, DiscordSocketClient discord, CommandService commands)
        {
            _discord = discord;
            _commands = commands;
            _provider = provider;
            _discord.ReactionAdded += HandleReactionAddedAsync;
            _discord.ReactionRemoved += HandleReactionRemovedAsync;
        }
        public async Task InitializeAsync(IServiceProvider provider)
        {
            _provider = provider;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), services: null);
            // Add additional initialization code here...
        }
        public void HookReactionAdded(BaseSocketClient client)
    => client.ReactionAdded += HandleReactionAddedAsync;
        public async Task HandleReactionAddedAsync(Cacheable<IUserMessage, ulong> cachedMessage, ISocketMessageChannel originChannel, SocketReaction reaction)
        {
            var message = await cachedMessage.GetOrDownloadAsync();
            if (message != null && reaction.User.IsSpecified && reaction.User.Value.Username != _discord.CurrentUser.Username && message.Id == 672388196025368578)
            {
                if (reaction.Emote.Name == "Unreal")
                    await (reaction.User.Value as SocketGuildUser).AddRoleAsync((originChannel as SocketGuildChannel).Guild.GetRole(672081697289797642));
                else if (reaction.Emote.Name == "Unity")
                    await (reaction.User.Value as SocketGuildUser).AddRoleAsync((originChannel as SocketGuildChannel).Guild.GetRole(672081724624076810));
                else if (reaction.Emote.Name == "Blender")
                    await (reaction.User.Value as SocketGuildUser).AddRoleAsync((originChannel as SocketGuildChannel).Guild.GetRole(672081747944407061));
                else if (reaction.Emote.Name == "3DSMax")
                    await (reaction.User.Value as SocketGuildUser).AddRoleAsync((originChannel as SocketGuildChannel).Guild.GetRole(672081770392584202));
                
            }
            else if (message != null && reaction.User.IsSpecified && reaction.User.Value.Username != _discord.CurrentUser.Username && message.Id == 672388202698375169)
            {   
                var categories = (originChannel as SocketGuildChannel).Guild.GetCategoryChannel(672377248065781760);
                var channel = await (originChannel as SocketGuildChannel).Guild.CreateTextChannelAsync(reaction.User.Value.Username, x =>
                {
                    x.CategoryId = categories.Id;
                    x.Topic = $"This Support Ticket was created at {DateTimeOffset.UtcNow} by {reaction.User}.";
                });
                var NewOverwrites = new OverwritePermissions(sendMessages: PermValue.Allow, viewChannel: PermValue.Allow, readMessageHistory: PermValue.Allow);
                await channel.AddPermissionOverwriteAsync(reaction.User.Value, NewOverwrites);
                await channel.SendMessageAsync($"{reaction.User.Value.Mention} Your Support Ticket has been opened, please type the Reason you need support below");
                await message.RemoveAllReactionsAsync();
                var emoji = new Emoji("\uD83C\uDFAB");
                await message.AddReactionAsync(emoji);
                var logchannel = _discord.GetChannel(672390262877716480) as IMessageChannel;
                var emoji2 = new Emoji("\u2705");
                await logchannel.SendMessageAsync($"{emoji2} - {reaction.User.Value.Username} has created a new support ticket");
            }
        }
        public void HookReactionRemoved(BaseSocketClient client)
    => client.ReactionRemoved += HandleReactionRemovedAsync;
        public async Task HandleReactionRemovedAsync(Cacheable<IUserMessage, ulong> cachedMessage, ISocketMessageChannel originChannel, SocketReaction reaction)
        {
            var message = await cachedMessage.GetOrDownloadAsync();
            if (message != null && reaction.User.IsSpecified && reaction.User.Value.Username != _discord.CurrentUser.Username && message.Id == 672388196025368578)
            {
                if (reaction.Emote.Name == "Unreal")
                    await (reaction.User.Value as SocketGuildUser).RemoveRoleAsync((originChannel as SocketGuildChannel).Guild.GetRole(672081697289797642));
                else if (reaction.Emote.Name == "Unity")
                    await (reaction.User.Value as SocketGuildUser).RemoveRoleAsync((originChannel as SocketGuildChannel).Guild.GetRole(672081724624076810));
                else if (reaction.Emote.Name == "Blender")
                    await (reaction.User.Value as SocketGuildUser).RemoveRoleAsync((originChannel as SocketGuildChannel).Guild.GetRole(672081747944407061));
                else if (reaction.Emote.Name == "3DSMax")
                    await (reaction.User.Value as SocketGuildUser).RemoveRoleAsync((originChannel as SocketGuildChannel).Guild.GetRole(672081770392584202));

            }
        }

    }
}
