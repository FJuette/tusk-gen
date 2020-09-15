using System;
using System.IO;
using System.Reflection;
using System.Text;


namespace tusk_gen
{
    public class QueryService
    {
        public string pereparePath(string className)
        {
            string pathString = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), className);

            pathString = System.IO.Path.Combine(pathString, "Queries");

            System.IO.Directory.CreateDirectory(pathString);

            return System.IO.Path.Combine(pathString, className + "Query.cs");
        }   

        public void createCommand(string pathString, string className, string nspace)
        {
            nspace = nspace + "." + className;

            if (!System.IO.File.Exists(pathString))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(pathString))
                {
                    var data = @"using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using $nspace.Exceptions;
using $nspace.Infrastructure;
using $nspace.Models;
using $nspace.Persistance;

namespace $nspace
{
    public class Get$classNameQuery : IRequest<Ref$classNameViewModel>
    {
    }

    public class Get$classNameQueryHandler : IRequestHandler<Get$classNameQuery, Ref$classNameViewModel>
    {

        public async Task<Ref$classNameViewModel> Handle(Get$classNameQuery request, CancellationToken cancellationToken)
        {
            return new Ref$classNameViewModel();
        }
    }

    public class Ref$classNameDto
    {
    }

    public class Ref$classNameProfile : Profile
    {
        public Ref$classNameProfile()
        {
           
        }
    }

    public class Ref$classNameViewModel
    {
        public List<Ref$classNameDto> Data { get; set; }
    }
}".PHPIt(new {nspace, className});

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