
namespace BLL_DokiHouse.Models
{
    public class NoteBLL
    {

        public NoteBLL(string title, string description, int idBonsai)
        {
            Title = title;
            Description = description;
            IdBonsai = idBonsai;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int IdBonsai { get; set; } // ---> FK
    }
}
