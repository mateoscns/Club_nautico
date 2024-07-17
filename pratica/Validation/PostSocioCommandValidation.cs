using FluentValidation;
using static pratica.Services.SociosServices.Commands.PostSocio;

namespace pratica.Validation
{
    public class PostSocioCommandValidation : AbstractValidator<PostSocioCommand>
    {
        public PostSocioCommandValidation()
        {
            RuleFor(s => s.Nombre).NotEmpty();

            RuleFor(s => s.Telefono).NotEmpty();

            RuleFor(s => s.Apellido).NotEmpty();
        }
    }
}
