using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Models.FilePicture;
using BLL_DokiHouse.Tools;
using DAL_DokiHouse.Interfaces;
using Entities_DokiHouse.Entities;


namespace BLL_DokiHouse.Services
{
    public class PictureBLLService : IPictureBLLService
    {

        #region Injection
        private readonly IPictureBonsaiRepo _pictureRepo;
        private readonly IUserBLLService _userBLLService;
        public PictureBLLService(IPictureBonsaiRepo pictureRepo, IUserBLLService userBLLService)
        => (_pictureRepo,_userBLLService) = (pictureRepo, userBLLService);

        #endregion


        #region private methods
        private bool IsImageFile(string file)
        {
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };

            return allowedExtensions.Any(ext => ext.Equals(Path.GetExtension(file), StringComparison.OrdinalIgnoreCase));
        }

        #endregion

        public async Task<bool> AddPictureBonsai(FilePictureModel filePicture, int idBonsai)
        {
            if(filePicture.File is null) 
                throw new ArgumentNullException(nameof(filePicture));

            if(!IsImageFile(filePicture.FileName)) 
                throw new ArgumentException("Le fichier n'est pas une image valide, format attendu .jpg .jpeg .png");

            if (!Directory.Exists(filePicture.FilePath))
                Directory.CreateDirectory(filePicture.FilePath);


            string uniqueFileName = Guid.NewGuid().ToString() + "_" + filePicture.FileName;


            using (var stream = new FileStream(Path.Combine(filePicture.FilePath, uniqueFileName), FileMode.OpenOrCreate))
            {
                await filePicture.File.CopyToAsync(stream);
            }


            PictureBonsai picture = Mapping.FilePictureCreateToDAL(filePicture);

            return await _pictureRepo.AddPictureBonsai(idBonsai,picture);
        }

    }
}
