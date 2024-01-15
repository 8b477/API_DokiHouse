using Entities_DokiHouse.Interfaces;

namespace Entities_DokiHouse.Entities
{
    public class Bonsai : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int IdUser { get; set; }
    }
}
