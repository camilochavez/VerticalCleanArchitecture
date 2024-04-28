using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SLinkUser.Domain.DTO
{
    public class AddressDTO
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
        public GeoDTO? Geo { get; set; }
    }

    public class GeoDTO
    {
        [Required]
        [JsonPropertyName("lat")]
        public string? Latitud { get; set; }

        [Required]
        [JsonPropertyName("lng")]
        public string? Longitude { get; set; }
    }
}
