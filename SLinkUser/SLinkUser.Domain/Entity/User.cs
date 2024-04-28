using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SLinkUser.Domain.Entity
{
    public class User
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        [Required]
        public string? Name { get; set; }
        
        [Required]
        public string? Username { get; set; }
        
        [Required]
        public string? Email { get; set; }
        
        [Required]
        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address? Address { get; set; }
        
        [Required]
        public string? Phone { get; set; }
        
        [Required]
        public string? Website { get; set; }
        
        [Required]
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company? Company { get; set; }
    }
}
