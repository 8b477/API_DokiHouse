using Entities_DokiHouse.Entities;

namespace DAL_DokiHouse.DTO
{
    public class UserAndPictureDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public PictureProfil? PictureProfil { get; set; }
    }
}
