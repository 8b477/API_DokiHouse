
namespace DAL_DokiHouse.DTO
{

    public record UserDTO
    {
        public UserDTO(){ }

        public UserDTO(string name, string email, string passwd, string role)
        {
            Name = name;
            Email = email;
            Passwd = passwd;
            Role = role;
        }


        public UserDTO(string name,string email, string passwd)
        {
            Name = name;
            Email = email;
            Passwd = passwd;
        }


        public int Id { get;  }
        public string Name { get;  }
        public string Email { get;  }
        public string Passwd { get;  }
        public string Role { get;  }
        public int? IdPictureProfil { get;  }
    }


    public record UserUpNameDTO
    {
        public UserUpNameDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; }
        public string Name { get; }
    }

    public record UserUpMailDTO
    {
        public UserUpMailDTO(int id, string mail)
        {
            Id = id;
            Email = mail;
        }
        public int Id { get; }
        public string Email { get; }
    }

    public record UserUpPassDTO
    {
        public UserUpPassDTO(int id, string pass)
        {
            Id = id;
            Passwd = pass;
        }
        public int Id { get; }
        public string Passwd { get; }
    }
}

