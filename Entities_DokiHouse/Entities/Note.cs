using Entities_DokiHouse.Interfaces;

namespace Entities_DokiHouse.Entities
{
    public class Note : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public int IdBonsai { get; set; } // ---> FK
    }
}
