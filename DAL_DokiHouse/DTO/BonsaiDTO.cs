
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

}
