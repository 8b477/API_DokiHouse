
using DAL_DokiHouse.Repository;
using Entities_DokiHouse.Entities;

namespace DAL_DokiHouse.DTO
{

    public record UserDTO
    {
        public UserDTO(){ }

        public UserDTO(string name, string email, string passwd,DateTime createAt, DateTime modifiedAt, string role)
        {
            Name = name;
            Email = email;
            Passwd = passwd;
            CreatedAt = createAt;
            ModifiedAt = modifiedAt;
            Role = role;
        }

        public UserDTO(string name, string email, string passwd, string role, DateTime modifiedAt)
        {
            Name = name;
            Email = email;
            Passwd = passwd;
            Role = role;
            ModifiedAt = modifiedAt;
        }

        public int Id { get;  }
        public string Name { get;  }
        public string Email { get;  }
        public string Passwd { get;  }
        public string Role { get;  }
        public DateTime CreatedAt { get; }
        public DateTime ModifiedAt { get; }
    }

    public record UserUpNameDTO
    {
        public UserUpNameDTO(int id, string name, DateTime modifiedAt)
        {
            Id = id;
            Name = name;
            ModifiedAt = modifiedAt;
        }
        public int Id { get; }
        public string Name { get; }
        public DateTime ModifiedAt { get; }
    }

    public record UserUpMailDTO
    {
        public UserUpMailDTO(int id, string mail, DateTime modifiedAt)
        {
            Id = id;
            Email = mail;
            ModifiedAt = modifiedAt;
        }
        public int Id { get; }
        public string Email { get; }
        public DateTime ModifiedAt { get; }
    }

    public record UserUpPassDTO
    {
        public UserUpPassDTO(int id, string pass, DateTime modifiedAt)
        {
            Id = id;
            Passwd = pass;
            ModifiedAt = modifiedAt;
        }
        public int Id { get; }
        public string Passwd { get; }
        public DateTime ModifiedAt { get; }
    }

    public class UserDetailsBonsaiDTO
    {
        public int IdUser { get; set; }
        public string Name { get; set; } = string.Empty;
        public PictureProfil? PictureProfil { get; set; }
        public List<BonsaiDetailsDTO>? Bonsais { get; set; }
    }

    public class UserDetailsPostDTO
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Name { get; set; } = string.Empty;
        public PictureProfil? PictureProfil { get; set; }
        public List<PostDTO>? Posts { get; set; }
    }
}

