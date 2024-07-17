using FluentValidation;
using static pratica.Services.SociosServices.Querys.GetSocioById;

namespace pratica.Validation
{
 
        public class GetSocioByIdQueryValidation : AbstractValidator<GetSocioByIdQuery>
        {
            public GetSocioByIdQueryValidation()
            {
                RuleFor(g => g.Id).NotEmpty();
            }
        }
    
}
