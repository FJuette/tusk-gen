using System;
using System.Reflection;
using System.IO;
using System.Text;

namespace tusk_gen
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length != 0)
            {
                if (args.Length == 1)
                {
                    if (args[0] == "--help" || args[0] == "--h")
                    {
                        CommandoHelper _commandHelper = new CommandoHelper();
                        _commandHelper.getHelperCommands();
                    }
                    else if (args[0] == "--version" || args[0] == "--v")
                    {
                        Console.WriteLine(Assembly.GetExecutingAssembly().GetName().Version.ToString());
                    }
                    else
                    {
                        UnkownCommand();
                    }
                }
                else if (args.Length == 3)
                {
                    if (args[0] == "query" || args[0] == "q" && args[1] != "" && args[2] != "")
                    {
                        Console.WriteLine("Name of the class: " + args[1]);

                        TemplateService _templateService = new TemplateService();

                        _templateService.build(args[1], args[2], "tusk_gen.Templates.Query.template", "Query");

                        //_queryService.pereparePath(args[1], args[2]);

                        //_queryService.createCommand(path, args[1], nspace);

                    }
                    else if (args[0] == "command" || args[0] == "c" && args[1] != "" && args[2] != "")
                    {
                        Console.WriteLine("Name of the class: " + args[1]);

                        /*CommandService _commandService = new CommandService();

                        var path = _commandService.pereparePath(args[1], args[2]);

                        _commandService.createCommand(path, args[1], nspace);
                        */

                        TemplateService _templateService = new TemplateService();

                        _templateService.build(args[1], args[2], "tusk_gen.Templates.Command.template", "Command");
                    }
                    else
                    {
                        UnkownCommand();
                    }
                }
                else
                {
                    UnkownCommand();
                }

            }
            else
            {
                UnkownCommand();
            }
        }
        static void UnkownCommand()
        {
            Console.WriteLine("Command is not valid! List with all commands: --help");
        }
    }

    static class StringExtensions
    {
        public static string PHPIt<T>(this string s, T values, string prefix = "$")
        {
            var sb = new StringBuilder(s);
            foreach (var p in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                sb = sb.Replace(prefix + p.Name, p.GetValue(values, null).ToString());
            }
            return sb.ToString();
        }
    }
}