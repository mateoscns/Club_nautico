using MediatR;
using Microsoft.EntityFrameworkCore;
using pratica.Data;
using pratica.Models;
using pratica.Validation;

namespace pratica.Services.SociosServices.Commands
{
    public class PutSocio
    {
        public class PutSocioCommand : IRequest<Socio>
        {
            public int Id { get; set; } = 0!;

            public string Nombre { get; set; } = null!;

            public string Apellido { get; set; } = null!;

            public string? Telefono { get; set; }
        }

        public class PutSocioHandler : IRequestHandler<PutSocioCommand, Socio>
        {

            private readonly ApplicationContext _context;
            private readonly PutSocioCommandValidation _validator;

            public PutSocioHandler(ApplicationContext context, PutSocioCommandValidation validator)
            {
                _context = context;
                _validator = validator;
            }


            public async Task<Socio> Handle(PutSocioCommand request, CancellationToken cancellationToken)
            {
                _validator.Validate(request);
                try
                {
                    var socio = await _context.Socios.FirstOrDefaultAsync(s => s.Id == request.Id);
                    if (socio != null)
                    {

                        
                        socio.Nombre = request.Nombre;
                        socio.Apellido = request.Apellido;
                        socio.Telefono = request.Telefono;

                        await _context.SaveChangesAsync();
                        return socio;
                    }
                    else
                    {
                        throw new ArgumentNullException(nameof(socio));
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
