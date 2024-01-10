
namespace DAL_DokiHouse.DTO
{
    public record NoteDTO
    {
        public NoteDTO() { }

        public NoteDTO(string title, string description, DateTime createAt, DateTime modifiedAt , int idBonsai)
        {
            Title = title;
            Description = description;
            CreateAt = createAt;
            ModifiedAt = modifiedAt;
            IdBonsai = idBonsai;
        }

        public int Id { get;  }
        public string Title { get;  }
        public string Description { get;  }
        public DateTime CreateAt { get;  }
        public DateTime ModifiedAt { get;  }
        public int IdBonsai { get;  } // ---> FK
    }

}
