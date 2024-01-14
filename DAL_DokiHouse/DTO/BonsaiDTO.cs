
using Entities_DokiHouse.Entities;

namespace DAL_DokiHouse.DTO
{

    public record BonsaiDTO
    {
        public BonsaiDTO()
        {
            
        }
        public BonsaiDTO(string name, string? description, DateTime modifiedAt, int idUser)
        {
            Name = name;
            Description = description;
            ModifiedAt = modifiedAt;
            IdUser = idUser;
        }

        public BonsaiDTO(string name, string? description, DateTime createAt , DateTime modifiedAt , int idUser)
        {
            Name = name;
            Description = description;
            CreatedAt = createAt;
            ModifiedAt = modifiedAt;
            IdUser = idUser;
        }

        public int Id { get;  }
        public string Name { get;  }
        public string? Description { get;  }
        public DateTime CreatedAt { get; }
        public DateTime ModifiedAt { get; }
        public int IdUser { get;  }
    }

    public class BonsaiDetailsDTO
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Name { get; set; } = string.Empty;
        public PictureBonsai? PictureBonsai { get; set; }
        public Category? Categories { get; set; }
        public Style? Styles { get; set; }
        public Note? Notes { get; set; }
    }
}
