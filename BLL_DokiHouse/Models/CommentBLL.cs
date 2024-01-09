

namespace BLL_DokiHouse.Models
{
    public class CommentBLL
    {
        public CommentBLL(string content, DateTime createdAt, int idUser)
        {
            Content = content;
            CreatedAt = createdAt;
            IdUser = idUser;
        }

        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int IdUser { get; set; }


    }
}
