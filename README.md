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
**Class:** Credits  
**Example:** Input: `qcredits 1`  
		Output: `Written in C# using the DSharpPlus Libraries, by Siri.`
### qadd
**Syntax:** `qadd <numberOne> <numberTwo>`  
**Conditions:** Requires an Integer to take the place of the `numberOne` and `numberTwo` variable.   
**Description:** Outputs a simple equation.  
**Class:** AddNumber  
**Example:** Input: `qadd 5 10`  
		Output: `5+10=15`   
		  
### qroll
**Syntax:** `qroll <max>`  
**Conditions:** Requires an Integer to take the place of the `max` variable.   
**Description:** Generates a Random Number between 1 and `max`.    
**Class:** Roll  
**Example:** Input: `qroll 20`  
		Output: `15`   
		
### qgamer  
**[CONTENT REDACTED]**
		  

		  
