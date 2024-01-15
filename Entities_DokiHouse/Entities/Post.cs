using Entities_DokiHouse.Interfaces;


namespace Entities_DokiHouse.Entities
{
    public class Post : IEntity<int>
	{
		public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int IdUser { get; set; }
    }
}
