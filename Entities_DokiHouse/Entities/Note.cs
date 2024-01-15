using Entities_DokiHouse.Interfaces;

namespace Entities_DokiHouse.Entities
{
    public class Note : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int IdUser { get; set; }
    }
}
