using Entities_DokiHouse.Entities;

namespace DAL_DokiHouse.DTO.Bonsai
{
    public class BonsaiDetailsDTO
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Name { get; set; } = string.Empty;
        public PictureBonsai? PictureBonsai { get; set; }
        public Category? Categories { get; set; }
        public Style? Styles { get; set; }
        public Note? Notes { get; set; }
    }
}
