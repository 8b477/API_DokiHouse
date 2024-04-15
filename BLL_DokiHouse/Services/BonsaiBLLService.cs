using API_DokiHouse.Models;

using BLL_DokiHouse.Extensions;
using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Models.Bonsai.View;
using BLL_DokiHouse.Tools;
using DAL_DokiHouse.Interfaces;
using Entities_DokiHouse.Entities;


namespace BLL_DokiHouse.Services
{
    public class BonsaiBLLService : IBonsaiBLLService
    {

        #region Injection

        private readonly IBonsaiRepo _bonsaiRepo;
        public BonsaiBLLService(IBonsaiRepo bonsaiRepo) => _bonsaiRepo = bonsaiRepo; 

        #endregion


        public async Task<BonsaiView?> CreateBonsai(BonsaiModel bonsai, int idToken)
        {
            Bonsai bonsaiDAL = Mapping.BonsaiCreateBLLtoDAL(bonsai);
            int idBonsai = await _bonsaiRepo.Create(bonsaiDAL, idToken);

            if (idBonsai == 0)
                return null;

            return bonsaiDAL.BLLToView(idBonsai, idToken);
        }


        public async Task<IEnumerable<Bonsai>> GetBonsais()
        {
            return await _bonsaiRepo.Get();
        }


        public async Task<IEnumerable<Bonsai>?> GetOwnBonsai(int id)
        {
            return await _bonsaiRepo.GetOwnBonsai(id);
        }


        public async Task<Bonsai?> GetBonsaiByID(int id)
        {
            Bonsai? bonsai = await _bonsaiRepo.GetBy(id);

            return bonsai is not null ? bonsai : null;
        }


        public async Task<IEnumerable<Bonsai>?> GetBonsaiByName(string name, string stringIdentifiant)
        {
            return await _bonsaiRepo.GetBy(name, stringIdentifiant);
        }


        public async Task<bool> UpdateBonsai(BonsaiModel model, int idBonsai)
        {
            Bonsai BonsaiDAl = Mapping.BonsaiUpdateBLLtoDAL(model);

            return await _bonsaiRepo.Update(BonsaiDAl, idBonsai);
        }


        public async Task<bool> DeleteBonsai(int id)
        {
            return await _bonsaiRepo.Delete(id);
        }

        public async Task<IEnumerable<BonsaiPictureDTO>?> GetBonsaiAndPicture(int idUser)
        {
            return await _bonsaiRepo.GetBonsaiAndPicture(idUser);
        }

        public async Task<IEnumerable<BonsaiPictureDTO>?> GetAllBonsaiAndPicture()
        {
            return await _bonsaiRepo.GetAllBonsaiAndPicture();
        }
    }
}
