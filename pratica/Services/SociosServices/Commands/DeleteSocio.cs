using MediatR;
using Microsoft.EntityFrameworkCore;
using pratica.Data;
using pratica.Models;
using pratica.Validation;

namespace pratica.Services.SociosServices.Commands
{
    public class DeleteSocio
    {

        public class DeleteSocioCommand : IRequest<Socio>
        {
            public int Id { get; set; }
        }

        public class DeleteSocioHandler : IRequestHandler<DeleteSocioCommand, Socio>
        {
            private readonly ApplicationContext _context;
            private readonly DeleteSocioCommandValidation _validator;

            public DeleteSocioHandler(ApplicationContext context, DeleteSocioCommandValidation validator)
            {
                _context = context;
                _validator = validator;
            }

            public async Task<Socio> Handle(DeleteSocioCommand request, CancellationToken cancellationToken)
            {
                _validator.Validate(request);
                try
                {
                    var socio = await _context.Socios.FirstOrDefaultAsync(s => s.Id == request.Id);
                    if (socio != null)
                    {
                        _context.Socios.Remove(socio);

                        await _context.SaveChangesAsync();

                        return socio;
                    }
                    else
                    {
                        throw new ArgumentNullException(nameof(Socio));
                    }
                    
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
