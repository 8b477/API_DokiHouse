
namespace BLL_DokiHouse.Models
{
    /// <summary>
    /// Permet de set l'IdBonsai pour créer lien entre l'objet Category et Bonsai
    /// </summary>
    public class CategoryBLL
    {
        public CategoryBLL(bool shohin, bool mame, bool chokkan, bool moyogi, bool shakan, bool kengai, bool hanKengai, bool ikadabuki, bool neagari, bool literati, bool yoseUe, bool ishitsuki, bool kabudachi, bool kokufu, bool yamadori, string? perso, int idBonsai)
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

        public bool Shohin { get; set; } = false;
        public bool Mame { get; set; } = false;
        public bool Chokkan { get; set; } = false;
        public bool Moyogi { get; set; } = false;
        public bool Shakan { get; set; } = false;
        public bool Kengai { get; set; } = false;
        public bool HanKengai { get; set; } = false;
        public bool Ikadabuki { get; set; } = false;
        public bool Neagari { get; set; } = false;
        public bool Literati { get; set; } = false;
        public bool YoseUe { get; set; } = false;
        public bool Ishitsuki { get; set; } = false;
        public bool Kabudachi { get; set; } = false;
        public bool Kokufu { get; set; } = false;
        public bool Yamadori { get; set; } = false;
        public string? Perso { get; set; } = "";

        public int IdBonsai { get; set; }
    }
}
