using FluentValidation;
using System.Data;
using static pratica.Services.SociosServices.Commands.PutSocio;

namespace pratica.Validation
{
    public class PutSocioCommandValidation : AbstractValidator<PutSocioCommand>
    {
        public PutSocioCommandValidation()
        {
            RuleFor(s => s.Id).NotEmpty();

            RuleFor(s => s.Nombre).NotEmpty();

            RuleFor(s => s.Telefono).NotEmpty();

            RuleFor(s => s.Apellido).NotEmpty();

        }
    }
}
