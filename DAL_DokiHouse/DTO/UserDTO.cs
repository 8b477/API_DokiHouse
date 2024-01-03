
using DAL_DokiHouse.DTO;

namespace DAL_DokiHouse.DTO
{
    public class UserDTO
    {
        public UserDTO()
        {

        }

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
        public string Name { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
        public string Role { get; set; }
        public int? IdPictureProfil { get; set; }
    }


    public record class UserCreateDTO
    {
        public UserCreateDTO(string name, string email, string passwd)
            => (Name, Email, Passwd) 
            =  (name, email, passwd);

        public string Name { get; }
        public string Email { get; }
        public string Passwd { get; set; }
    }


    public record class UserDisplayDTO
    {

        public UserDisplayDTO() { }


        public UserDisplayDTO(int id, string name, int? idPictureProfil)
            => (Id, Name, IdPictureProfil) 
            =  (id, name, idPictureProfil);


        public int Id { get; }
        public string Name { get; }
        public int? IdPictureProfil { get; }
    }


}

