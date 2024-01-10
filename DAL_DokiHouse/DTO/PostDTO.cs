

namespace DAL_DokiHouse.DTO
{
    public record PostDTO
    {
        public PostDTO() {}
        public PostDTO(string title, string description, string content, DateTime createAt, DateTime modifiedAt, int idUser)
        {
            Title = title;
            Description = description;
            Content = content;
            CreateAt = createAt;
            ModifiedAt = modifiedAt;
            IdUser = idUser;
        }

        public int Id { get;  }
        public string Title { get; }
        public string Description { get;  }
        public string Content { get;  }
        public DateTime CreateAt { get;  }
        public DateTime? ModifiedAt { get;  }
        public int IdUser { get;  } // --> FK
    }
}
