using System;


namespace tusk_gen
{
    public class CommandTemplate
    {
        public string getCommandTemplate(string nspace, string className, string nspaceclass)
        {
             return @"using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using $nspace.Models;
using FluentValidation;
using AutoMapper;
using AutoMapper.QueryableExtensions;



namespace $nspaceclass
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


}".PHPIt(new {nspaceclass, nspace, className});
        }
    }
}