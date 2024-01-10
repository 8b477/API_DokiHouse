using Entities_DokiHouse.Interfaces;

namespace Entities_DokiHouse.Entities
{
    public class PictureProfil : IEntity<int>
    {
        public int Id { get; set; }
        public byte[] Picture { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
