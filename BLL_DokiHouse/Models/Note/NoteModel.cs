using System.ComponentModel.DataAnnotations;

namespace API_DokiHouse.Models
{
#nullable disable
    public class NoteModel
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Le champ 'Title' est requis et peut contenir max 100 caractères")]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
#nullable enable
}