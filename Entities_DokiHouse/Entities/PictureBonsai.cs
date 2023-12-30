using Entities_DokiHouse.Interfaces;

namespace Entities_DokiHouse.Entities
{
    public class PictureBonsai : IEntity<int>
    {
        public int Id { get; set; }
        public byte[] Picture { get; set; }

        public int IdUser { get; set; } // ---> FK
    }
}
