using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using pratica.Data;
using pratica.Dtos;
using pratica.Models;

namespace pratica.Services.SociosServices.Querys
{
    public class GetAllSocios
    {
        public class GetAllSociosQuery : IRequest<List<SocioDTO>>
        {

        }

        public class GetAllSociosQueryHandler : IRequestHandler<GetAllSociosQuery, List<SocioDTO>>
        {

            private readonly ApplicationContext _context;
            private readonly IMapper _mapper;

            public GetAllSociosQueryHandler(ApplicationContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<SocioDTO>> Handle(GetAllSociosQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var socios = await _context.Socios.ToListAsync();
                    if(socios.Count != 0)
                    {
                        return _mapper.Map<List<SocioDTO>>(socios);
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
