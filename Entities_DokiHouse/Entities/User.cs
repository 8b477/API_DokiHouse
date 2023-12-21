using Entities_DokiHouse.Interfaces;

namespace Entities_DokiHouse.Entities
{
    public class User : IEntity<int>
    {
        public int Id { get; set; }
        public string Pseudo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Passwd { get; set; } = string.Empty;
        public Image? Picture { get; set; }
        public string? Role { get; set; }
    } 
}
