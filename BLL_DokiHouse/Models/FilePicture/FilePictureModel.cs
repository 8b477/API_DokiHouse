using Microsoft.AspNetCore.Http;

namespace BLL_DokiHouse.Models.FilePicture
{
    public class FilePictureModel
    {
        public IFormFile? File { get; set; }
        public string FileFolder { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int IdBonsai { get; set; }
    }
}
