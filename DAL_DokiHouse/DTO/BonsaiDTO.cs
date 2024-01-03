
namespace DAL_DokiHouse.DTO
{

    public class BonsaiDTO
    {

        public BonsaiDTO() { }

        public BonsaiDTO(string name, string? description, int idUser)
        {
            Name = name;
            Description = description;
            IdUser = idUser;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int IdUser { get; set; }
    }



    public class BonsaiAndChild
    {
        public BonsaiAndChild(){}

        public int IdBonsai { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int IdUser { get; set; }

        public BonsaiDTO Bonsai { get; set; }
        public CategoryDTO Category { get; set; }
        public StyleDTO Style { get; set; }
        public NoteDTO Note { get; set; }
    }



}
