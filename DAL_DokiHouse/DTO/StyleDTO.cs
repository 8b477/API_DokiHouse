
namespace DAL_DokiHouse.DTO
{
    public record class StyleDTO
    {

        public StyleDTO()
        {

        }


        public StyleDTO(bool chokkan, bool moyogi, bool shakan, bool kengai, bool hanKengai, bool ikadabuki, bool neagari, bool bunjin, bool yoseUe, bool ishitsuki, bool kabudachi, bool bankan, bool korabuki, bool yamadori, bool ishituki, string? perso, int idBonsai)
        {
            Chokkan = chokkan;
            Moyogi = moyogi;
            Shakan = shakan;
            Kengai = kengai;
            HanKengai = hanKengai;
            Ikadabuki = ikadabuki;
            Neagari = neagari;
            Bunjin = bunjin;
            YoseUe = yoseUe;
            Ishitsuki = ishitsuki;
            Kabudachi = kabudachi;
            Bankan = bankan;
            Korabuki = korabuki;
            Yamadori = yamadori;
            Ishituki = ishituki;
            Perso = perso;
            IdBonsai = idBonsai;
        }

        public int Id { get; }
        public bool Chokkan { get; }
        public bool Moyogi { get; }
        public bool Shakan { get; }
        public bool Kengai { get; }
        public bool HanKengai { get; }
        public bool Ikadabuki { get; }
        public bool Neagari { get; }
        public bool Bunjin { get; }
        public bool YoseUe { get; }
        public bool Ishitsuki { get; }
        public bool Kabudachi { get; }
        public bool Bankan { get; }
        public bool Korabuki { get; }
        public bool Yamadori { get; }
        public bool Ishituki { get; }
        public string? Perso { get; }

        public int IdBonsai { get; } //---> FK
    }
}
