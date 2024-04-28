using System.ComponentModel.DataAnnotations;

namespace SLinkUser.Feature.Contracts
{
    public class CreateUserRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Phone { get; set; }

        [Required]
        public string? Website { get; set; }

        [Required]
        public CreateUserAddressRequest? Address { get; set; }

        [Required]
        public CreateUserCompanyRequest? Company { get; set; }
    }

    public class CreateUserAddressRequest
    {
        [Required]
        public string? Street { get; set; }

        [Required]
        public string? Suite { get; set; }

        [Required]
        public string? City { get; set; }

        [Required]
        public string? Zipcode { get; set; }

        [Required]
        public CreateUserGeoRequest? Geo { get; set; }
    }

    public class CreateUserGeoRequest
    {
        [Required]
        public string? Latitud { get; set; }

        [Required]
        public string? Longitude { get; set; }
    }

    public class CreateUserCompanyRequest
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? CatchPhrase { get; set; }

        [Required]
        public string? Bs { get; set; }
    }

}
