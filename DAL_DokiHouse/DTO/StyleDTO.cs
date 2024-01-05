
namespace DAL_DokiHouse.DTO
{
    public record StyleDTO
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

        public int Id { get;  }
        public bool Bunjin { get;  }
        public bool Bankan { get;  }
        public bool Korabuki { get;  }
        public bool Ishituki { get;  }
        public string? Perso { get;  }

        public int IdBonsai { get;  } //---> FK
    }
}
