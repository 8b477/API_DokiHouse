
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
}
