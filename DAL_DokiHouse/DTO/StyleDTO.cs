
namespace DAL_DokiHouse.DTO
{
    public class StyleDTO
    {

        public StyleDTO(){}

        public StyleDTO(bool bunjin, bool bankan, bool korabuki, bool ishituki, string? perso, int idBonsai)
        {
            Bunjin = bunjin;
            Bankan = bankan;
            Korabuki = korabuki;
            Ishituki = ishituki;
            Perso = perso;
            IdBonsai = idBonsai;
        }

        public int Id { get; set; }
        public bool Bunjin { get; set; }
        public bool Bankan { get; set; }
        public bool Korabuki { get; set; }
        public bool Ishituki { get; set; }
        public string? Perso { get; set; }

        public int IdBonsai { get; set; } //---> FK
    }
}
