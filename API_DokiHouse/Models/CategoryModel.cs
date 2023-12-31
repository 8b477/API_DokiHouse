﻿namespace API_DokiHouse.Models
{
    public class CategoryModel
    {
        public int Id { get; set; } = 0;
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

        public int IdBonsai { get; set; } = 0;
    }
}