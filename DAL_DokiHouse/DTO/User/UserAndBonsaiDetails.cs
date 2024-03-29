﻿using DAL_DokiHouse.DTO.Bonsai;
using Entities_DokiHouse.Entities;

namespace DAL_DokiHouse.DTO.User
{
    public class UserAndBonsaiDetails
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public PictureProfil? PictureProfil { get; set; }
        public List<BonsaiDetailsDTO>? BonsaiDetails { get; set; }
    }
}
