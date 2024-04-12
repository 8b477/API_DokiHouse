

namespace BLL_DokiHouse.Models.Bonsai.View
{
    public record class BonsaiView
    {
        public BonsaiView(int id, string name, string? description, DateTime createAt, DateTime? modifiedAt, int idUser)
        {
            Id = id;
            Name = name;
            Description = description;
            CreateAt = createAt;
            ModifiedAt = modifiedAt;
            IdUser = idUser;
        }

        public int Id { get; init; }
        public string Name { get; init; }
        public string? Description { get; init; }
        public DateTime CreateAt { get; init; }
        public DateTime? ModifiedAt { get; init; }
        public int IdUser { get; set; }

    }
}
