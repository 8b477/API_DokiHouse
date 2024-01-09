using Entities_DokiHouse.Interfaces;

#nullable disable
namespace Entities_DokiHouse.Entities
{
    public class Post : IEntity<int>
	{
		public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }
        public int IdUser { get; set; } // --> FK

	}
}
