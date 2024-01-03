using System.ComponentModel.DataAnnotations;

namespace API_DokiHouse.Models
{

    public class CategoryModel
    {
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
        
        [MaxLength(150,ErrorMessage = "Ne peut contenir plus de 150 caractères")]
        public string? Perso { get; set; }
    }
}
