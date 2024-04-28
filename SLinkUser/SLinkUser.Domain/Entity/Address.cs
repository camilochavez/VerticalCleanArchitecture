using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLinkUser.Domain.Entity
{
    public class Address
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public string? Street { get; set; }
        
        [Required]
        public string? Suite { get; set; }
        
        [Required]
        public string? City { get; set; }
        
        [Required]
        public string? Zipcode { get; set; }
        
        [Required]
        public string? Latitud { get; set; }
        
        [Required]
        public string? Longitude { get; set;}
    }
}
