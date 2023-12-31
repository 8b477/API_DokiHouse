﻿using BLL_DokiHouse.Interfaces;
using DAL_DokiHouse.Interfaces;

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


        // -------------------------------------------------------------------------------------------> TODO
       
        public async Task<int> AddPictureBonsai(IFormFile file)
        {
            int idPicture = await _pictureRepo.AddPictureBonsai(file);

            return idPicture;
        }



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


    }
}
