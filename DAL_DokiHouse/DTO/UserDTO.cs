
namespace DAL_DokiHouse.DTO
{
    public record class UserDTO
    {
        public UserDTO()
        {

        }

        public UserDTO(string name, string email, string passwd, int? idPictureProfil, string role)
        {
            Name = name;
            Email = email;
            Passwd = passwd;
            IdPictureProfil = idPictureProfil;
            Role = role;
        }

        public int Id { get; }
        public string Name { get; }
        public string Email { get; }
        public string Passwd { get; }
        public int? IdPictureProfil { get; }
        public string Role { get; }
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