using System.ComponentModel.DataAnnotations;

namespace SLinkUser.Domain.DTO
{
    public class UpdateUserDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Username { get; set; }
    }
}
