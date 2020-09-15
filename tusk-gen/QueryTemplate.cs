using System;


namespace tusk_gen
{
    public class QueryTemplate
    {
        public string getQueryTemplate(string nspace, string className)
        {
             return @"using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using $nspace.Exceptions;
using $nspace.Infrastructure;
using $nspace.Models;

namespace $nspaceclass
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
        }
    }
}