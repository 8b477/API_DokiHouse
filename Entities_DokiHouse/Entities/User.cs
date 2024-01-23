using Entities_DokiHouse.Interfaces;

namespace Entities_DokiHouse.Entities
{
    public class User : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Passwd { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    } 
}
