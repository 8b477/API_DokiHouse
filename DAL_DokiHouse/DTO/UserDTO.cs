

namespace DAL_DokiHouse.DTO
{

    public record UserDTO
    {
        public UserDTO(){ }

        public UserDTO(string name, string email, string passwd)
        {
            Name = name;
            Email = email;
            Passwd = passwd;
        }

        public UserDTO(string name, string email, string passwd, string role) : this(name, email, passwd)
        {
            Role = role;
        }

        public UserDTO(string name, string email, string passwd, int? idPictureProfil, string role)
        {
            Name = name;
            Email = email;
            Passwd = passwd;
            IdPictureProfil = idPictureProfil;
            Role = role;
        }

        public UserDTO(int id, string name, string role, int? idPictureProfil)
        {
            Id = id;
            Name = name;
            Role = role;
            IdPictureProfil = idPictureProfil;
        }

        public int Id { get; set; }
        public string Name { get;  }
        public string Email { get;  }
        public string Passwd { get;  }
        public string Role { get;  }
        public int? IdPictureProfil { get;  }
    }
}

