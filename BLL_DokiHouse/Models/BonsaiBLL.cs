
namespace BLL_DokiHouse.Models
{
    public class BonsaiBLL
    {
        public BonsaiBLL(string name, string description, int idUser)
        {
            Name = name;
            Description = description;
            IdUser = idUser;
        }

        public string Name { get; set; }
        public string Description{ get; set; }
        public int IdUser { get; set; }

    }
}
