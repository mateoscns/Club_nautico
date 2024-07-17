using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using pratica.Data;
using pratica.Models;
using pratica.Validation;
using static pratica.Services.SociosServices.Querys.GetSocioById;

namespace pratica.Services.SociosServices.Commands
{
    public class PostSocio
    {

        public class PostSocioCommand : IRequest<Socio>
        {
            public string Nombre { get; set; } = null!;

            public string Apellido { get; set; } = null!;

            public string? Telefono { get; set; }
        }


        public class PostSocioHandler : IRequestHandler<PostSocioCommand, Socio>
        {

            private readonly ApplicationContext _context;
            private readonly PostSocioCommandValidation _validator;

            public PostSocioHandler(ApplicationContext context, PostSocioCommandValidation validator)
            {
                _context = context;
                _validator = validator;
            }


            public async Task<Socio> Handle(PostSocioCommand request, CancellationToken cancellationToken)
            {
                _validator.Validate(request);
                try
                {
                    Socio socio = new Socio();
                    socio.Nombre = request.Nombre;
                    socio.Apellido = request.Apellido;
                    socio.Telefono = request.Telefono;
                    await _context.Socios.AddAsync(socio);
                    await _context.SaveChangesAsync();

                    return socio;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
