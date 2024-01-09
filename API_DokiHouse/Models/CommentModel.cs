using System.ComponentModel.DataAnnotations;

namespace API_DokiHouse.Models
{
    public class CommentModel
    {
        [Required]
        public string Content { get; set; }
    }
}
