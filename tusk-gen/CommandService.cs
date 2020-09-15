using System;
using System.IO;
using System.Reflection;
using System.Text;


namespace tusk_gen
{
    public class CommandService
    {
        public string pereparePath(string className)
        {
            string pathString = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), className);

            pathString = System.IO.Path.Combine(pathString, "Commands");

            System.IO.Directory.CreateDirectory(pathString);

            return System.IO.Path.Combine(pathString, className + "Command.cs");
        }   

        public void createCommand(string pathString, string className, string nspace)
        {
            nspace = nspace + "." + className;

            if (!System.IO.File.Exists(pathString))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(pathString))
                {
                    var data = @"using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;
using TUCLib.Core;
using Windranger.Api.Models;
using Windranger.Api.Persistance;
using FluentValidation;
using AutoMapper;
using AutoMapper.QueryableExtensions;



namespace $nspace
{
    public class $classNameCommand : IRequest<bool>
    {

    }

    public class $classNameCommandHandler : IRequestHandler<$classNameCommand, $classNameViewModel>
    {
       
        public async Task<$classNameViewModel> Handle($classNameCommand request, CancellationToken cancellationToken)
        {
        }

    }

     public class CreateProjectValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectValidator()
        {
            //RuleFor(x => x.Identity).NotEmpty()
            //    .WithMessage('Der Id eines neuen Projekts darf nicht leer sein.');

        }
    }

    public class GetUpdateProjectProfile : Profile
    {
        public GetUpdateProjectProfile()
        {
        }
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