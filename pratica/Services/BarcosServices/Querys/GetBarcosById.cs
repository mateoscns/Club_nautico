using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using pratica.Data;
using pratica.Dtos;
using pratica.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace pratica.Services.BarcosServices.Querys
{
    public class GetBarcoById
    {
        public class GetBarcoByIdQuery : IRequest<BarcoDTO>
        {
            public int Id { get; set; }

            public GetBarcoByIdQuery(int id)
            {
                Id = id;
            }
        }

        public class GetBarcoByIdQueryHandler : IRequestHandler<GetBarcoByIdQuery, BarcoDTO>
        {
            private readonly ApplicationContext _context;
            private readonly IMapper _mapper;

            public GetBarcoByIdQueryHandler(ApplicationContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BarcoDTO> Handle(GetBarcoByIdQuery request, CancellationToken cancellationToken)
            {
                var barco = await _context.Barcos
                    .Include(b => b.IdSocioNavigation)
                    .FirstOrDefaultAsync(b => b.Id == request.Id);

                if (barco == null)
                {
                    throw new InvalidOperationException("Barco not found");
                }

                return _mapper.Map<BarcoDTO>(barco);
            }
        }
    }
}
