using FluentValidation;

namespace SLinkUser.API.Features.UpdateUser
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.Id).GreaterThan(0);            
            RuleFor(r => r.Username).NotEmpty();
        }
    }


}
