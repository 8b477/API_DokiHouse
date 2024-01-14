

using Entities_DokiHouse.Entities;

namespace DAL_DokiHouse.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set;  }
        public string Content { get; set;  }
        public DateTime CreateAt { get; set;  }
        public DateTime? ModifiedAt { get; set;  }
        public int IdUser { get; set;  } // --> FK
        public List<Comments>? Comments { get; set; }
    }
}
