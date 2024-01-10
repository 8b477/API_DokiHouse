
namespace DAL_DokiHouse.DTO
{
    public record CategoryDTO
    {

        public CategoryDTO() { }


        public CategoryDTO(bool shohin, bool mame, bool chokkan, bool moyogi, bool shakan, bool kengai, bool hanKengai, bool ikadabuki, bool neagari, bool literati, bool yoseUe, bool ishitsuki, bool kabudachi, bool kokufu, bool yamadori, string? perso, DateTime createdAt, DateTime modifiedAt, int idBonsai)
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
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
            IdBonsai = idBonsai;
        }


        public int Id { get;  }
        public bool Shohin { get;  } 
        public bool Mame { get;  }
        public bool Chokkan { get;  }
        public bool Moyogi { get;  }
        public bool Shakan { get;  }
        public bool Kengai { get;  }
        public bool HanKengai { get;  }
        public bool Ikadabuki { get;  }
        public bool Neagari { get;  }
        public bool Literati { get;  }
        public bool YoseUe { get;  }
        public bool Ishitsuki { get;  }
        public bool Kabudachi { get;  }
        public bool Kokufu { get;  }
        public bool Yamadori { get;  }
        public string? Perso { get;  }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int IdBonsai { get;  } // ---> FK
    }

}

