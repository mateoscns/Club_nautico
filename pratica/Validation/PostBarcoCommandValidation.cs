using FluentValidation;
using static pratica.Services.BarcosServices.Commands.PostBarco;

namespace pratica.Validation
{
    public class PostBarcoCommandValidation : AbstractValidator<PostBarcoCommand>
    {
        public PostBarcoCommandValidation()
        {
            RuleFor(s => s.NumMatricula).NotEmpty();
            RuleFor(s => s.Nombre).NotEmpty();
            RuleFor(s => s.NumAmarre).NotEmpty();

        }
  

    }
}
