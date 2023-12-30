using System.ComponentModel.DataAnnotations;

namespace API_DokiHouse.Models
{
    public class BonsaiModel
    {
        public record BonsaiCreateModel
        {
            [Required(ErrorMessage = $"{nameof(Name)} : champ requis")]
            [MinLength(3, ErrorMessage = $"Le champ {nameof(Name)} est requis et doit comporter au min 3 caratères")]
            [MaxLength(20, ErrorMessage = $"Le champ {nameof(Name)} est requis et doit comporter au max 20 caratères")]
            public string Name { get; set; } = string.Empty;

            public string? Description { get; set; }
        }

    }
}
