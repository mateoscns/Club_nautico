using FluentValidation;
using static pratica.Services.SociosServices.Commands.DeleteSocio;

namespace pratica.Validation
{
    public class DeleteSocioCommandValidation : AbstractValidator<DeleteSocioCommand>
    {
        public DeleteSocioCommandValidation()
        {
            RuleFor(s => s.Id).NotEmpty();
        }

       
    }
}
