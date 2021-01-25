using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus;
using DSharpPlus.Interactivity;
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
            string[] content = { "Written in C# using the DSharpPlus Libraries, by Siri.", "Source Code available at https://github.com/Siri-chan/DiscordBot (link may be subject to change)" };
            if (page <= content.Length + 1 & page > 0)
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
            // limit is roughly 2125000000
        }
        [Command("gamer")]
        [Description("[CONTENT REDACTED]")]
        public async Task gamer(CommandContext ctx)
        {
            await ctx.Member.SendMessageAsync("https://drive.google.com/drive/folders/1wf-q6U0_k6IDGD3nEqVQQOOyUZ9GtPtp").ConfigureAwait(false);
        }
        [Command("492")]
        [Description("This one is pretty self explanatory")]
        public async Task fourHundredAndNinetyTwo(CommandContext ctx, [Description("yes.")] int not492)
        {
            if (not492 % 492 == 0)
            {
                int div492 = not492 / 492;
                if (div492 % 10 > 2)
                {
                    await ctx.Channel.SendMessageAsync(not492.ToString() + " is the " + div492.ToString() + "th multiple of 492.").ConfigureAwait(false);
                }
                else if (div492 % 10 == 2)
                {
                    await ctx.Channel.SendMessageAsync(not492.ToString() + " is the " + div492.ToString() + "nd multiple of 492.").ConfigureAwait(false);
                }
                else if (div492 % 10 == 1)
                {
                    await ctx.Channel.SendMessageAsync(not492.ToString() + " is the " + div492.ToString() + "st multiple of 492.").ConfigureAwait(false);
                }
                else
                {
                    await ctx.Channel.SendMessageAsync("i can't believe you didn't think i would add this stupid gag in here for if you were a smartass and put zero in").ConfigureAwait(false);
                }
            }
            else
            {
                await ctx.Channel.SendMessageAsync("This number is not divisible by 492, and it leaves a remainder of " + not492 % 492).ConfigureAwait(false);
            }
        }
        /*        [Command("timezone")]
                [Description("Gathers a location's timezone based on `longitude`")]
                public async Task Roll(CommandContext ctx, [Description("The location's longitude.")] float longitude)
                {
                    int timezone = 0;
                    if (longitude > 180 || longitude < -180)
                    {

                    }
                    else
                    {
                        if (longitude = longitude)
                        {
                            await ctx.Channel.SendMessageAsync("Latitude: " + longitude).ConfigureAwait(false);
                            await ctx.Channel.SendMessageAsync("Timezone: GMT+" + timezone).ConfigureAwait(false);
                            // Will finish *later* once i bother to copy+paste longitude if loops and counteract for Daylight Savings, weird jaggedy timezone edges
                        }
                    }
                }*/
        [Command("repeat")]
        [Description("Repeats the channel's next message back")]
        public async Task repeat(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();
            await ctx.Channel.SendMessageAsync("{awaiting message}").ConfigureAwait(false);
            var message = await interactivity.WaitForMessageAsync(x => x.Channel == ctx.Channel).ConfigureAwait(false);
            await ctx.Channel.SendMessageAsync(message.Result.Content).ConfigureAwait(false);
        }
        [Command("repeatemoji")]
        [Description("Repeats the channel's next emoji back")]
        public async Task repeatEmoji(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();
            await ctx.Channel.SendMessageAsync("{awaiting reaction}").ConfigureAwait(false);
            var message = await interactivity.WaitForReactionAsync(x => x.Channel == ctx.Channel && x.User == ctx.User).ConfigureAwait(false);
            await ctx.Channel.SendMessageAsync(message.Result.Emoji).ConfigureAwait(false);
        }
        [Command("fizzbuzz")]
        [Description("Play the simple game of fizzbuzz.")]
        public async Task FizzBuzz(CommandContext ctx, [Description("Determines how long the game goes on for.")] int length)
        {
            // This game is still a little broken, it will treat every user's response as an entry to the game, and will occasionally recieve the same message twice (discord's servers sometimes recieve msgs multiple times)
            // It will also count any input as an answer to the game, which can be fixed by a simple if(){} that checks the message content is an integer or fizz/buzz/fizzbuzz , but i'm too lazy to glue it in for now, because it will inevitably fail in some way
            bool winning = true;
            int fizz = 3;
            int buzz = 5;
            var interactivity = ctx.Client.GetInteractivity();
            await ctx.Channel.SendMessageAsync("Count to " + length + ". You must replace " + fizz + "s with 'fizz' and " + buzz +"s with 'buzz'. Numbers that match both should be answered with 'fizzbuzz'.").ConfigureAwait(false);
            for (int i = 1; i <= length; i++)
            {
                var message = await interactivity.WaitForMessageAsync(x => x.Channel == ctx.Channel).ConfigureAwait(false);
                if (i % fizz == 0)
                {
                    if (i % buzz == 0)
                    {
                        if (message.Result.Content == "fizzbuzz")
                        {
                            await ctx.Channel.SendMessageAsync("good").ConfigureAwait(false);
                        }
                        else
                        {
                            await ctx.Channel.SendMessageAsync("bad, correct was fizzbuzz").ConfigureAwait(false);
                            winning = false;
                            break;
                        }
                    }
                    else
                    {
                        if (message.Result.Content == "fizz")
                        {
                            await ctx.Channel.SendMessageAsync("good").ConfigureAwait(false);
                        }
                        else
                        {
                            await ctx.Channel.SendMessageAsync("bad, correct was fizz").ConfigureAwait(false);
                            winning = false;

                            break;
                        }
                    }
                }
                else if (i % buzz == 0)
                {
                    if (message.Result.Content == "buzz")
                    {
                        await ctx.Channel.SendMessageAsync("good").ConfigureAwait(false);
                    }
                    else
                    {
                        await ctx.Channel.SendMessageAsync("bad, correct was buzz").ConfigureAwait(false);
                        winning = false;
                        break;

                    }
                }
                else
                {
                    if (message.Result.Content == i.ToString())
                    {
                        await ctx.Channel.SendMessageAsync("good").ConfigureAwait(false);
                    }
                    else
                    {
                        await ctx.Channel.SendMessageAsync("bad, correct was " + i).ConfigureAwait(false);
                        winning = false;
                        break;
                    }
                }
            }
            if (winning == true)
            {
                await ctx.Channel.SendMessageAsync("Poggers, You Win!").ConfigureAwait(false);
            }
            else
            {
                await ctx.Channel.SendMessageAsync("KEKW, You lost a simple kid's game!").ConfigureAwait(false);
            }
        }
    }
}

