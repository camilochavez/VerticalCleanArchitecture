using System.ComponentModel.DataAnnotations;

namespace SLinkUser.Domain.DTO
{
    public class UserDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Phone { get; set; }

        [Required]
        public string? Website { get; set; }

        [Required]
        public AddressDTO? Address { get; set; }

        [Required]
        public CompanyDTO? Company { get; set; }
    }
}
