using System.ComponentModel.DataAnnotations;

namespace API_DokiHouse.Models
{
    public class StyleModel
    {
        public bool Bunjin { get; set; }
        public bool Bankan { get; set; }
        public bool Korabuki { get; set; }
        public bool Ishituki { get; set; }

        [MaxLength(150, ErrorMessage = "Ne peut contenir plus de 150 caractères")]
        public string? Perso { get; set; }
    }
}
