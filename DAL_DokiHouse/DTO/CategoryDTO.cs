
using DAL_DokiHouse.DTO;

namespace DAL_DokiHouse.DTO
{
    public class CategoryDTO
    {

        public CategoryDTO() { }


        public CategoryDTO(bool shohin, bool mame, bool chokkan, bool moyogi, bool shakan, bool kengai, bool hanKengai, bool ikadabuki, bool neagari, bool literati, bool yoseUe, bool ishitsuki, bool kabudachi, bool kokufu, bool yamadori, string? perso, int idBonsai)
        {
            Shohin = shohin;
            Mame = mame;
            Chokkan = chokkan;
            Moyogi = moyogi;
            Shakan = shakan;
            Kengai = kengai;
            HanKengai = hanKengai;
            Ikadabuki = ikadabuki;
            Neagari = neagari;
            Literati = literati;
            YoseUe = yoseUe;
            Ishitsuki = ishitsuki;
            Kabudachi = kabudachi;
            Kokufu = kokufu;
            Yamadori = yamadori;
            Perso = perso;
            IdBonsai = idBonsai;
        }


        public int Id { get; set; }
        public bool Shohin { get; set; } 
        public bool Mame { get; set; }
        public bool Chokkan { get; set; }
        public bool Moyogi { get; set; }
        public bool Shakan { get; set; }
        public bool Kengai { get; set; }
        public bool HanKengai { get; set; }
        public bool Ikadabuki { get; set; }
        public bool Neagari { get; set; }
        public bool Literati { get; set; }
        public bool YoseUe { get; set; }
        public bool Ishitsuki { get; set; }
        public bool Kabudachi { get; set; }
        public bool Kokufu { get; set; }
        public bool Yamadori { get; set; }
        public string? Perso { get; set; }

        public int IdBonsai { get; set; } // ---> FK
    }


    public record class CategoryDisplayDTO
    {

        public CategoryDisplayDTO() {}

        public CategoryDisplayDTO(bool shohin, bool mame, bool chokkan, bool moyogi, bool shakan, bool kengai, bool hanKengai, bool ikadabuki, bool neagari, bool literati, bool yoseUe, bool ishitsuki, bool kabudachi, bool kokufu, bool yamadori, string? perso)
        {
            Shohin = shohin;
            Mame = mame;
            Chokkan = chokkan;
            Moyogi = moyogi;
            Shakan = shakan;
            Kengai = kengai;
            HanKengai = hanKengai;
            Ikadabuki = ikadabuki;
            Neagari = neagari;
            Literati = literati;
            YoseUe = yoseUe;
            Ishitsuki = ishitsuki;
            Kabudachi = kabudachi;
            Kokufu = kokufu;
            Yamadori = yamadori;
            Perso = perso;
        }


        public bool Shohin { get; }
        public bool Mame { get; }
        public bool Chokkan { get; }
        public bool Moyogi { get; }
        public bool Shakan { get; }
        public bool Kengai { get; }
        public bool HanKengai { get; }
        public bool Ikadabuki { get; }
        public bool Neagari { get; }
        public bool Literati { get; }
        public bool YoseUe { get; }
        public bool Ishitsuki { get; }
        public bool Kabudachi { get; }
        public bool Kokufu { get; }
        public bool Yamadori { get; }
        public string? Perso { get; }
    }
}

