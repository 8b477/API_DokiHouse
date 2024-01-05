
namespace BLL_DokiHouse.Models
{
    /// <summary>
    /// Role principal permettre le set de la propriété 'Passwd' pour hash le pass
    /// </summary>
    public class UserBLL
    {
        public UserBLL(string name, string passwd)
        {
            Name = name;
            Passwd = passwd;
        }

        public UserBLL(string name, string email, string passwd, string role)
        {
            Name = name;
            Email = email;
            Passwd = passwd;
            Role = role;
        }

        public UserBLL(int id, string name, string email, string passwd)
        {
            Id = id;
            Name = name;
            Email = email;
            Passwd = passwd;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
        public string Role { get; set; }
    }


    public class UserUpdatePassBLL
    {
        public UserUpdatePassBLL(string passwd) => Passwd = passwd;

        public string Passwd { get; set; }
    }

    public class UserUpdateNameBLL
    {
        public UserUpdateNameBLL(string name) => Name = name;

        public string Name { get; set; }
    }

    public class UserUpdateMailBLL
    {
        public UserUpdateMailBLL(string email) => Email = email;

        public string Email { get; set; }
    }
}
