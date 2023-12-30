
namespace DAL_DokiHouse.DTO
{
    public record UserDTO
    {
        public UserDTO(string name, string email, string passwd, int? idPictureProfil, string role)
            => (Name ,Email, Passwd, IdPictureProfil, Role) = (name, email, passwd, idPictureProfil, role);

        public string Name { get; }
        public string Email { get; }
        public string Passwd { get; }
        public int? IdPictureProfil { get;}
        public string Role { get; }
    }


    public record UserCreateDTO
    {
        public UserCreateDTO(string name, string email, string passwd)
            => (Name, Email, Passwd) = (name, email, passwd);

        public string Name { get; }
        public string Email { get;  }
        public string Passwd { get;  }
    }


    public record UserDisplayDTO
    {
        public UserDisplayDTO(){ } // ---> Dapper a besoin d'un constructeur vide

        public UserDisplayDTO(int id, string name, int? idPictureProfil)
            => (Id, Name, IdPictureProfil) = (id, name, idPictureProfil);

        public int Id { get; }
        public string Name { get; }
        public int? IdPictureProfil { get; }
    }
}