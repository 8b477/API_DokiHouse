

namespace DAL_DokiHouse.DTO
{
    public record CommentsDTO
    {
        public CommentsDTO(string content, DateTime createdAt, int idUser)
        {
            Content = content;
            CreatedAt = createdAt;
            IdUser = idUser;
        }

        public string Content { get;  }
        public DateTime CreatedAt { get;  }
        public int IdUser { get;  } 
    }
}
