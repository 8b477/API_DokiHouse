
namespace DAL_DokiHouse.DTO
{
    public record StyleDTO
    {

        public StyleDTO(){}

        public StyleDTO(bool bunjin, bool bankan, bool korabuki, bool ishituki, string? perso, DateTime createAt, DateTime modifiedAt, int idBonsai)
        {
            Bunjin = bunjin;
            Bankan = bankan;
            Korabuki = korabuki;
            Ishituki = ishituki;
            Perso = perso;
            CreatedAt = createAt;
            ModifiedAt = modifiedAt;
            IdBonsai = idBonsai;
        }

        public int Id { get; }
        public bool Bunjin { get; }
        public bool Bankan { get; }
        public bool Korabuki { get; }
        public bool Ishituki { get; }
        public string? Perso { get; }
        public DateTime CreatedAt { get; }
        public DateTime ModifiedAt { get; }
        public int IdBonsai { get;  } //---> FK
    }
}
