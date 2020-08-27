﻿using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBot.Commands
{
    public class commands : BaseCommandModule
    {
        [Command("credits")]
        [Description("returns information about the bot.")]
        public async Task Credits(CommandContext ctx, [Description("1: General Credits; 2: Source Code")] int page)
        {
            string[] content = { "Written in C# using the DSharpPlus Libraries, by Siri.", "Source Code available at https://github.com/Siri-chan/DiscordBotTest (link may be subject to change)" };
            if (page == 1 || page == 2)
            {
                await ctx.Channel.SendMessageAsync(content[page - 1]).ConfigureAwait(false);
            }
            else
            {
                await ctx.Channel.SendMessageAsync("Please type the command with a valid page number; eg. `qcredits 1`").ConfigureAwait(false);
            }
        }
        [Command("add")]
        [Description("Adds 2 Numbers Together")]
        public async Task AddNumber(CommandContext ctx, [Description("The Number that you are adding to numberTwo.")] int numberOne, [Description("The Number that you are adding to numberOne.")] int numberTwo)
        {
            await ctx.Channel.SendMessageAsync((numberOne).ToString() + "+" + (numberTwo).ToString() + "=" + (numberOne + numberTwo).ToString()).ConfigureAwait(false);
        }
        [Command("roll")]
        [Description("Rolls a Random Integer between 1 and `max`")]
        public async Task Roll(CommandContext ctx, [Description("The maximum number you can acheive by rolling.")] int max)
        {
            Random rnd = new Random();
            int diceRoll = 0;
            diceRoll = rnd.Next(1, max + 1);
            await ctx.Channel.SendMessageAsync((diceRoll).ToString()).ConfigureAwait(false);
        }
        [Command("gamer")]
        [Description("[CONTENT REDACTED]")]
        public async Task gamer(CommandContext ctx)
        {
            await ctx.Member.SendMessageAsync("https://drive.google.com/drive/folders/1wf-q6U0_k6IDGD3nEqVQQOOyUZ9GtPtp").ConfigureAwait(false);
        }
    }
}

