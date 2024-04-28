using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SLinkUser.Domain.Entity
{
    public class Company
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? CatchPhrase { get; set; }
        
        [Required]
        public string? Bs { get; set; }
    }
}
