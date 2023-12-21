using Entities_DokiHouse.Interfaces;

namespace Entities_DokiHouse.Entities
{
    public class Image : IEntity<int>
    {
        public int Id { get; set; }
        public byte[] Picture { get; set; }

        public User IdUser { get; set; }
    }
}
