﻿
namespace DAL_DokiHouse.DTO
{
    public class NoteDTO
    {
        public NoteDTO()
        {

        }

        public NoteDTO(string title, string description, DateTime createAt, int idBonsai)
        {
            Title = title;
            Description = description;
            CreateAt = createAt;
            IdBonsai = idBonsai;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public int IdBonsai { get; set; } // ---> FK
    }

}
