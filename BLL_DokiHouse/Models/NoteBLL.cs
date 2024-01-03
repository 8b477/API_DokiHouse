
namespace BLL_DokiHouse.Models
{
    public class NoteBLL
    {

        public NoteBLL(string title, string description, DateTime createAt, int idBonsai)
        {
            Title = title;
            Description = description;
            CreateAt = createAt;
            IdBonsai = idBonsai;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public int IdBonsai { get; set; } // ---> FK
    }
}
