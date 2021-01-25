# DiscordBot  
A simple test bot program written in C# with DSharpPlus. 
## Setup
For this to work you need to create a file titled config.json in `/bin/Debug/netcoreapp3.x` that reads 
```
{
	"token": "<insert here>",
	"prefix": "<insert here>",
}
```
Then, compile it with Microsoft .NET.  
## Commands
### qcredits
**Syntax:** `qcredits <page>`  
**Conditions:** Requires an Integer to take the place of the `page` variable. Page 1 = General Credits; Page 2 = Source Code  
**Description:** Provides information about the bot. 
**Class:** `Credits`  
**Example:** Input: `qcredits 1`  
			Output: `Written in C# using the DSharpPlus Libraries, by Siri.`
### qadd
**Syntax:** `qadd <numberOne> <numberTwo>`  
**Conditions:** Requires an Integer to take the place of the `numberOne` and `numberTwo` variable.   
**Description:** Outputs a simple equation.  
**Class:** `AddNumber`  
**Example:** Input: `qadd 5 10`  
			Output: `5+10=15`   
		  
### qroll
**Syntax:** `qroll <max>`  
**Conditions:** Requires an Integer to take the place of the `max` variable.   
**Description:** Generates a Random Number between 1 and `max`.    
**Class:** `Roll`  
**Example:** Input: `qroll 20`  
			Output: `15`   
		
### qgamer  
**[CONTENT REDACTED]**

### q492  
**Syntax:** `q492 <not492>`  
**Conditions:** Requires a positive integer to replace the `not492` variable.  
**Description:** This one's quite self-explanatory.  
**Class:** `fourHundredAndNinetyTwo`  
**Example:** Input: `q492 984`  
			Output: `984 is the 2nd multiple of 492.`  

_qtimezone is an unfinished command, fully commented out in the code_

### qrepeat
**Syntax:** `qrepeat`  
**Conditions:** Requires another message to be sent after the command.  
**Description:** Repeats the channel's next message back.  
**Class:** `repeat`
**Example:** Input: `qrepeat`  
			Output: `{awaiting message}`  
			Input: `haha gay`  
			Output: `haha gay`  

###  qrepeatemoji
**Syntax:** `qrepeatemoji`  
**Conditions:** Requires a message to be reacted to after the command.  
**Description:** Repeats the channel's next emoji back.  
**Class:** `repeatEmoji`
**Example:** Input: `qrepeatemoji`  
			Output: `{awaiting reaction}`  
			Input: *User reacts to the bot's message with :ok_hand:*  
			Output: `:ok_hand:`  

### qfizzbuzz  
**Syntax:** `qfizzbuzz <length>`  
**Conditions:** Requires a positive integer to take the place of the `length` variable. You must also continue to play the game after sending the command.  
**Description:** Play the simple game of fizzbuzz.  
**Class:** `FizzBuzz`  
**Example:** Input: `qfizzbuzz 100`  
			Output: `Count to 100. You must replace 3s with 'fizz' and 5s with 'buzz'. Numbers that match both should be answered with 'fizzbuzz'.  
			_user plays the game lol_  



## Distribution
Feel free to distribute/build the bot in whatever config and with whatever alterations you wish, just make sure to credit every previous author.

## Bugs and Issues
Let's be honest. I make a lot of dumb mistakes. If you find one, feel free to use the issues page at https://github.com/Siri-chan/DiscordBot to report bugs, or create your own branch to fix them.
