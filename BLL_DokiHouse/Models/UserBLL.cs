
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

        public UserBLL(string name, string email, string passwd)
        {
            Name = name;
            Email = email;
            Passwd = passwd;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
    }

}
