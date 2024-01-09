

namespace DAL_DokiHouse.DTO
{
    public record CommentsDTO
    {
        public CommentsDTO(string content, DateTime createdAt, int idUser, int idPost)
        {
            Content = content;
            CreatedAt = createdAt;
            IdUser = idUser;
            IdPost = idPost;
        }

        public string Content { get;  }
        public DateTime CreatedAt { get;  }
        public int IdUser { get;  }
        public int IdPost { get; }
    }
}
