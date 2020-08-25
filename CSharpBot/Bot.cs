using CSharpBot.Commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBot
{
    public class Bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }
        public async Task RunAsync()
        {
            var json = string.Empty;
            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);

            var configJson = JsonConvert.DeserializeObject<ConfigJSON>(json);

            var config = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                LogLevel = LogLevel.Debug,
                UseInternalLogHandler = true,
            };
            Client = new DiscordClient(config);
            Client.Ready += OnReady;
            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.Prefix },
                EnableMentionPrefix = true,
                EnableDms = false,
                IgnoreExtraArguments = true,
            };
            Commands = Client.UseCommandsNext(commandsConfig);
            Commands.RegisterCommands<commands>();
            await Client.ConnectAsync();
            await Task.Delay(-1);
        }
        private Task OnReady(ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
//client id = 747636593774559232
//https://discord.com/api/oauth2/authorize?client_id=747636593774559232&scope=bot&permissions=1