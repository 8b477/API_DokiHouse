using System.ComponentModel.DataAnnotations;

namespace API_DokiHouse.Models
{
    public class CommentModel
    {
#nullable disable
        [Required]
        [MaxLength(int.MaxValue)]
        public string Content { get; set; }
#nullable enable
    }
}
