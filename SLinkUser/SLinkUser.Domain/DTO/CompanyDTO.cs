using System.ComponentModel.DataAnnotations;

namespace SLinkUser.Domain.DTO
{
    public class CompanyDTO
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? CatchPhrase { get; set; }

        [Required]
        public string? Bs { get; set; }
    }
}
