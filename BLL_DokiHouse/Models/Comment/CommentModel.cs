using System.ComponentModel.DataAnnotations;

namespace API_DokiHouse.Models
{
    public class CommentModel
    {
#nullable disable
        [Required]
        public string Content { get; set; }
#nullable enable
    }
}
