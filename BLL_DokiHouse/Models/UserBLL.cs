
namespace BLL_DokiHouse.Models
{
    public class UserBLL
    {
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
