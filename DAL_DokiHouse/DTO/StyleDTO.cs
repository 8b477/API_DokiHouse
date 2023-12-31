
namespace DAL_DokiHouse.DTO
{
    public class StyleDTO
    {
        public int Id { get; set; }
        public bool Chokkan { get; set; }
        public bool Moyogi { get; set; }
        public bool Shakan { get; set; }
        public bool Kengai { get; set; }
        public bool HanKengai { get; set; }
        public bool Ikadabuki { get; set; }
        public bool Neagari { get; set; }
        public bool Bunjin { get; set; }
        public bool YoseUe { get; set; }
        public bool Ishitsuki { get; set; }
        public bool Kabudachi { get; set; }
        public bool Bankan { get; set; }
        public bool Korabuki { get; set; }
        public bool Yamadori { get; set; }
        public bool Ishituki { get; set; }
        public string? Perso { get; set; }

        public int IdBonsai { get; set; } //---> FK
    }
}
