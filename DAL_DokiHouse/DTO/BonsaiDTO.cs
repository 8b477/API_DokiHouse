
namespace DAL_DokiHouse.DTO
{

    public record BonsaiDTO
    {
        public BonsaiDTO(int id, string name, string? description, int idUser)
        {
            Id = id;
            Name = name;
            Description = description;
            IdUser = idUser;
        }
        public int Id { get; }
        public string Name { get; }
        public string? Description { get; }
        public int IdUser { get; }
    }


    public record BonsaiCreateDTO
    {
        public BonsaiCreateDTO(string name, string? description, int idUser)
        {
            Name = name;
            Description = description;
            IdUser = idUser;
        }
        public string Name { get; }
        public string? Description { get; }
        public int IdUser { get; }
    }


    public record BonsaiDisplayDTO
    {
        public BonsaiDisplayDTO() { }

        public BonsaiDisplayDTO(int id,string name, string? description, int idUser)
        {
            Id = id;
            Name = name;
            Description = description;
            IdUser = idUser;
        }
        public int Id { get; }
        public string Name { get; }
        public string? Description { get; }
        public int IdUser { get; }
    }


    public class BonsaiAndChild
    {
        public int IdBonsai { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }
        public int IdUser { get; set; }
        public CategoryDTO Category { get; set; }

        public StyleDTO Style { get; set; }
        public NoteDTO Note { get; set; }
    }
}
