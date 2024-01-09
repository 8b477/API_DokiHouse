﻿using Entities_DokiHouse.Interfaces;

namespace Entities_DokiHouse.Entities
{
#nullable disable
    public class Comments : IEntity<int>
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int IdUser { get; set; } // --> Fk
    }
}
