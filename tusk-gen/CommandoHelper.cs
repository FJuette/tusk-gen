using System;


namespace tusk_gen
{
    public class CommandoHelper
    {

        public void getHelperCommands()
        {

            var commands = @"List of all available Commands:


gen --help or gen -h                                                    // outputs a list of all available commands!

gen --version or gen -v                                                 // outputs the tool-verison!

gen command [className] [pathName] or gen c [className] [pathName]      // generates a default command with your chossen classname and pathname!

gen query [className] [pathName] or gen q [className] [pathName]        // generates a default query with your chossen classname and pathname!";

            Console.WriteLine(commands);
        }
    }
}