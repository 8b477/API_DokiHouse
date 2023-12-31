
namespace DAL_DokiHouse.DTO
{
    public class NoteDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public int IdBonsai { get; set; } // ---> FK
    }
}
