

namespace Entities_DokiHouse.Entities
{
    public class Category
    {
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
        public string? CatePerso { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int IdBonsai { get; set; } // ---> FK

    }
}
/*

	[Perso] VARCHAR(150),
	[IdBonsai] INT NOT NULL,
	FOREIGN KEY (IdBonsai) REFERENCES [Bonsai](Id)*/