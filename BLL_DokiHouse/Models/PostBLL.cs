

namespace BLL_DokiHouse.Models
{
    public class PostBLL
    {
        public PostBLL(string title, string description, string content, int idUser)
        {
            Title = title;
            Description = description;
            Content = content;
            IdUser = idUser;
        }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public int IdUser { get; set; }
    }
}
