using MediatR;
using SLinkUser.Domain;
using System.ComponentModel.DataAnnotations;

namespace SLinkUser.API.Features.DeleteUser
{
    public class DeleteUserCommand : IRequest<Result<bool, ErrorResponse>>
    {
        [Required]
        public int Id { get; set; }
    }
}
