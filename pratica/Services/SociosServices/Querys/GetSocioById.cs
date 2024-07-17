using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using pratica.Data;
using pratica.Models;
using pratica.Validation;

namespace pratica.Services.SociosServices.Querys
{
    public class GetSocioById
    {

        public class GetSocioByIdQuery : IRequest<Socio>
        {
            public int Id { get; set;  }
        }


        public class GetSocioByIdQueryHandler : IRequestHandler<GetSocioByIdQuery, Socio>
        {

            private readonly ApplicationContext _context;
            private readonly GetSocioByIdQueryValidation _validator;

            public GetSocioByIdQueryHandler(ApplicationContext context, GetSocioByIdQueryValidation validator)
            {
                _context = context;
                _validator = validator;
            }


            public async Task<Socio> Handle(GetSocioByIdQuery request, CancellationToken cancellationToken)
            {
                _validator.Validate(request);
                try
                {
                    var socio = await _context.Socios.FirstOrDefaultAsync(s => s.Id == request.Id);
                    if (socio != null)
                    {
                        return socio;
                    }
                    else
                    {
                        throw new ArgumentNullException(nameof(socio));
                    }
                        
                }
                catch( Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
