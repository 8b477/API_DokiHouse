using Entities_DokiHouse.Interfaces;

using System.Data.Common;

namespace Entities_DokiHouse.Entities
{
    public class Style :IEntity<int>
    {
        public int Id { get; set; }
        public bool Bunjin { get; set; }
        public bool Bankan { get; set; }
        public bool Korabuki { get; set; }
        public bool Ishituki { get; set; }
        public string? Perso { get; set; }

        public int IdBonsai { get; set; } //---> FK
    }

}
