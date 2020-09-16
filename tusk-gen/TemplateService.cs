using System;
using System.Reflection;
using System.IO;
using System.Text;
using System.Xml;

namespace tusk_gen
{
    public class TemplateService
    {
        public bool build(string className, string pathName, string resourceName, string commandType)
        {
            var path = pereparePath(className, pathName, commandType);

            var nspace = getNamespace();

            createCommand(path, className, nspace, resourceName);

            return true;
        }
        private string pereparePath(string className, string pathName, string commandType)
        {
            string pathString = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), pathName);

            pathString = System.IO.Path.Combine(pathString, commandType);

            System.IO.Directory.CreateDirectory(pathString);

            return System.IO.Path.Combine(pathString, className + commandType + ".cs");
        }
        private string getNamespace()
        {
            try
            {
                var paths = System.IO.Directory.GetFiles(System.IO.Directory.GetCurrentDirectory(), "*.csproj");

                string xmlFile = File.ReadAllText(paths[0]);
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.LoadXml(xmlFile);
                    XmlNodeList nodeList = xmldoc.GetElementsByTagName("RootNamespace");

                return nodeList[0].InnerText;
            }
            catch
            {
                Console.WriteLine("Namespace not found!");
            }

            return "ProjektNameSpace";

            
        }
        private void createCommand(string pathString, string className, string nspace, string resourceName)
        {
            var nspaceclass = nspace + "." + className;

            if (!System.IO.File.Exists(pathString))
            {
                using (System.IO.FileStream fileStream = System.IO.File.Create(pathString))
                {
                    var assembly = Assembly.GetExecutingAssembly();

                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(reader.ReadToEnd().PHPIt(new {nspaceclass, nspace, className}));

                        fileStream.Write(bytes, 0, bytes.Length);
                    }
                }
            }
            else
            {
                Console.WriteLine("File already exists.");
            }

            Console.WriteLine("Finished!");
        }
    }
}