using Entities_DokiHouse.Interfaces;

namespace Entities_DokiHouse.Entities
{
    public class PictureBonsai : IEntity<int>
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int IdBonsai { get; set; }
    }
}
