using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ConsumerApi2.Application.Dto
{
    public class MessageDto
    {
        [JsonIgnore]
        public string? Id { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int SkiId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string SkiProductNo { get; set; }
        [Required]
        [Range(600, 6000)]
        public int PriceInPLN { get; set; }
        [Required]
        [Range(110, 195)]
        public int SkiLengthInCm { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string SkiProducent { get; set; }
    }
}
