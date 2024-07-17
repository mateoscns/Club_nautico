using MediatR;
using Microsoft.EntityFrameworkCore;
using pratica.Data;
using pratica.Models;

namespace pratica.Services.SociosServices.Querys
{
    public class GetAllSocios
    {
        public class GetAllSociosQuery : IRequest<List<Socio>>
        {

        }

        public class GetAllSociosQueryHandler : IRequestHandler<GetAllSociosQuery, List<Socio>>
        {

            private readonly ApplicationContext _context;

            public GetAllSociosQueryHandler(ApplicationContext context)
            {
                _context = context;
            }

            public async Task<List<Socio>> Handle(GetAllSociosQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var socios = await _context.Socios.ToListAsync();
                    if(socios.Count != 0)
                    {
                        return socios;
                    }
                    else
                    {
                        throw new Exception("No hay socios en la base de datos");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

    }
}
