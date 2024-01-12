using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Tools;

using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;

using Entities_DokiHouse.Entities;

using Microsoft.AspNetCore.Http;


namespace BLL_DokiHouse.Services
{
    public class PictureBLLService : IPictureBLLService
    {

        #region Injection
        private readonly IPictureRepo _pictureRepo;
        private readonly IUserBLLService _userBLLService;
        public PictureBLLService(IPictureRepo pictureRepo, IUserBLLService userBLLService)
        => (_pictureRepo,_userBLLService) = (pictureRepo, userBLLService);

        #endregion


        private bool IsImageFile(string file)
        {
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };

            return allowedExtensions.Any(ext => ext.Equals(Path.GetExtension(file), StringComparison.OrdinalIgnoreCase));
        }
       

        public async Task<bool> AddPictureBonsai(IFormFile file, string filePath, int idBonsai)
        {
            if(file is null) 
                throw new ArgumentNullException(nameof(file));

            if(!IsImageFile(file.FileName)) 
                throw new ArgumentException("Le fichier n'est pas une image valide, format attendu .jpg .jpeg .png");

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);


            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;


            using (var stream = new FileStream(Path.Combine(filePath, uniqueFileName), FileMode.OpenOrCreate))
            {
                await file.CopyToAsync(stream);
            }

            PictureBonsaiDTO pictureDTO = new (){ FileName = filePath , CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now , IdBonsai = idBonsai};

            return await _pictureRepo.AddPictureBonsai(pictureDTO);
        }


        /*
        public async Task<int> AddPictureProfil(int idUser, IFormFile file)
        {

            int idPicturePofil = await _pictureRepo.AddPictureProfil(file);

            await _userBLLService.UpdateProfilPicture(idUser, idPicturePofil);

            return idPicturePofil;
        }



        public async Task<IEnumerable<byte[]?>> GetImageBonsai(int idUser)
        {
            return await _pictureRepo.GetImageBonsai(idUser);
        }



        public async Task<byte[]?> GetImageProfil(int idPicture)
        {
            return await _pictureRepo.GetImageProfil(idPicture);
        }

        */
    }
}
