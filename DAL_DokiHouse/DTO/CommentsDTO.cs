

namespace DAL_DokiHouse.DTO
{
    public record CommentsDTO
    {
        public CommentsDTO(){}
        public CommentsDTO(string content, DateTime createdAt, DateTime modifiedAt, int idUser, int idPost)
        {
            Content = content;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
            IdUser = idUser;
            IdPost = idPost;
        }

        public string Content { get;  }
        public DateTime CreatedAt { get;  }
        public DateTime ModifiedAt { get; }
        public int IdUser { get;  }
        public int IdPost { get; }
    }
}
