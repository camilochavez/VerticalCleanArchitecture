using FluentValidation;

namespace SLinkUser.API.Features.DeleteUser
{
    public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.Id).GreaterThan(0);
        }
    }
}
