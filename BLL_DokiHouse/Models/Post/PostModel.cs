using System.ComponentModel.DataAnnotations;

namespace API_DokiHouse.Models
{
    public class PostModel
    {
#nullable disable
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;


        [Required]
		[MaxLength (200)]
		public string Description { get; set; } = string.Empty;


		[Required]
        public string Content { get; set; } = string.Empty;
#nullable enable
    }
}
