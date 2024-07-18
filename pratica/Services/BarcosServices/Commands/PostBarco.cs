using MediatR;
using pratica.Data;
using pratica.Dtos;
using pratica.Models;
using pratica.Validation;
using AutoMapper;
using FluentValidation;

namespace pratica.Services.BarcosServices.Commands
{
    public class PostBarco
    {
        public class PostBarcoCommand : IRequest<BarcoDTO>
        {
            public int NumMatricula { get; set; }
            public string Nombre { get; set; } = null!;
            public int NumAmarre { get; set; }
            public double Cuota { get; set; }
            public int IdSocio { get; set; }
        }

        public class PostBarcoHandler : IRequestHandler<PostBarcoCommand, BarcoDTO>
        {
            private readonly ApplicationContext _context;
            private readonly IMapper _mapper;
            private readonly IValidator<PostBarcoCommand> _validator;

            public PostBarcoHandler(ApplicationContext context, IMapper mapper, IValidator<PostBarcoCommand> validator)
            {
                _context = context;
                _mapper = mapper;
                _validator = validator;
            }

            public async Task<BarcoDTO> Handle(PostBarcoCommand request, CancellationToken cancellationToken)
            {
                var validationResult = await _validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.Errors);
                }

                var barco = _mapper.Map<Barco>(request);
                barco.IdSocioNavigation = await _context.Socios.FindAsync(request.IdSocio);

                if (barco.IdSocioNavigation == null)
                {
                    throw new InvalidOperationException("Socio not found");
                }

                await _context.Barcos.AddAsync(barco, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<BarcoDTO>(barco);
            }
        }
    }


}

