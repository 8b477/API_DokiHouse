
namespace BLL_DokiHouse.Models.User.View
{
    public record UserView
    {
        public UserView(int id, string name, string role, DateTime createAt, DateTime? modifiedAt)
        {
            Id = id;
            Name = name;
            Role = role;
            CreateAt = createAt;
            ModifiedAt = modifiedAt;
        }

        public int Id { get; init; }
        public string Name { get; init; }
        public string Role { get; init; }
        public DateTime CreateAt { get; init; }
        public DateTime? ModifiedAt { get; init; }
    }
}
