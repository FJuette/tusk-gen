using System;
using System.Text;


namespace tusk_gen
{
    public class QueryService
    {
        public string pereparePath(string className, string pathName)
        {
            string pathString = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), pathName);

            pathString = System.IO.Path.Combine(pathString, "Queries");

            System.IO.Directory.CreateDirectory(pathString);

            return System.IO.Path.Combine(pathString, className + "Query.cs");
        }   

        public void createCommand(string pathString, string className, string nspace)
        {
            var nspaceclass = nspace + "." + className;


            if (!System.IO.File.Exists(pathString))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(pathString))
                {
                    QueryTemplate _queryTemplate = new QueryTemplate();

                    var data = _queryTemplate.getQueryTemplate(nspace, className);

                    byte[] bytes = Encoding.UTF8.GetBytes(data);

                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            else
            {
                Console.WriteLine("File already exists.");
                return;
            }

            Console.WriteLine("Finished!");
        }
    }
}