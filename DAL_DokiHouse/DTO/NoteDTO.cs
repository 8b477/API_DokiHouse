
namespace DAL_DokiHouse.DTO
{
    public record NoteDTO
    {
        public NoteDTO() { }

        public NoteDTO(string title, string description, DateTime createAt, int idBonsai)
        {
            Title = title;
            Description = description;
            CreateAt = createAt;
            IdBonsai = idBonsai;
        }

        public int Id { get;  }
        public string Title { get;  }
        public string Description { get;  }
        public DateTime CreateAt { get;  }
        public int IdBonsai { get;  } // ---> FK
    }

}
