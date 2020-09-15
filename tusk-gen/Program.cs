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
                string nspace = getNamespace();

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

                        QueryService _queryService = new QueryService();

                        var path = _queryService.pereparePath(args[1], args[2]);

                        _queryService.createCommand(path, args[1], nspace);

                    }
                    else if (args[0] == "command" || args[0] == "c" && args[1] != "" && args[2] != "")
                    {
                        Console.WriteLine("Name of the class: " + args[1]);

                        CommandService _commandService = new CommandService();

                        var path = _commandService.pereparePath(args[1], args[2]);

                        _commandService.createCommand(path, args[1], nspace);
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

        static string getNamespace()
        {
            try
            {
                using (var sr = new StreamReader("Startup.cs"))
                {
                    var content = sr.ReadToEnd();
                    var split_content = content.Split(new char[0]);

                    for (int i = 0; i < split_content.Length; i++)
                    {
                        if (split_content[i].Contains("namespace"))
                        {
                            var index = i + 1;
                            return split_content[index];
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Cannot get Namespace! Startup.cs not found!");
            }

            return "ProjectNamespace";
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
