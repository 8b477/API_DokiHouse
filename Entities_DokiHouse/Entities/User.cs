using Entities_DokiHouse.Interfaces;

namespace Entities_DokiHouse.Entities
{
    public class User : IEntity<int>
    {
        public int Id { get; set; }
        public string Pseudo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Passwd { get; set; } = string.Empty;
        public byte[]? Picture { get; set; } = null;
        public string? Role { get; set; } = null;
    }
}
