

namespace BLL_DokiHouse.Models
{
    public class CommentBLL
    {
        public CommentBLL(string content, DateTime createdAt, int idUser, int idPost)
        {
            Content = content;
            CreatedAt = createdAt;
            IdUser = idUser;
            IdPost = idPost;
        }

        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int IdUser { get; set; }

        public int IdPost { get; set; }
    }
}
