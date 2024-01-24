using Entities_DokiHouse.Entities;

namespace DAL_DokiHouse.DTO.Post
{
    public class PostAndCommentDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int IdUser { get; set; }
        public List<Comments>? Comments { get; set; }
    }
}
