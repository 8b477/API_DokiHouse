﻿using Entities_DokiHouse.Interfaces;

namespace Entities_DokiHouse.Entities
{
#nullable disable
    public class Comments : IEntity<int>
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int IdPost { get; set; }
        public int IdUser { get; set; }
    }
}
