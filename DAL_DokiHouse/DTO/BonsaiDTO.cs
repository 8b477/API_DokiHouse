
namespace DAL_DokiHouse.DTO
{

    public record BonsaiDTO
    {

        public BonsaiDTO() { }

        public BonsaiDTO(string name, string? description, int idUser)
        {
            Name = name;
            Description = description;
            IdUser = idUser;
        }

        public int Id { get;  }
        public string Name { get;  }
        public string? Description { get;  }
        public int IdUser { get;  }
    }



    //public record BonsaiAndChild
    //{
    //    public BonsaiAndChild(){}

    //    public int IdBonsai { get;  }
    //    public string Name { get;  }
    //    public string? Description { get;  }
    //    public int IdUser { get;  }

    //    public BonsaiDTO Bonsai { get;  }
    //    public CategoryDTO Category { get;  }
    //    public StyleDTO Style { get;  }
    //    public NoteDTO Note { get;  }
    //}



}
