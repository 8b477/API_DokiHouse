namespace DAL_DokiHouse.DTO
{
    public class PictureBonsaiDTO
    {
        public string FileName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int IdBonsai { get; set; } // ---> FK
    }
}
