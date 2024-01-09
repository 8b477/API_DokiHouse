using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Models;
using BLL_DokiHouse.Tools;
using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;

using System.Collections.Generic;

namespace BLL_DokiHouse.Services
{
    public class BonsaiBLLService : IBonsaiBLLService
    {

        #region Injection

        private readonly IBonsaiRepo _bonsaiRepo;
        public BonsaiBLLService(IBonsaiRepo bonsaiRepo) => _bonsaiRepo = bonsaiRepo; 

        #endregion


        public async Task<bool> CreateBonsai(BonsaiBLL model)
        {
            BonsaiDTO bonsaiDTO = Mapper.BonsaiBLLToDAL(model);

            return await _bonsaiRepo.Create(bonsaiDTO);
        }


        public async Task<IEnumerable<BonsaiDTO>> GetBonsais()
        {
            return await _bonsaiRepo.Get();
        }

        public async Task<IEnumerable<BonsaiDTO?>> GetOwnBonsai(int id)
        {
            return await _bonsaiRepo.GetOwnBonsai(id);
        }

        public async Task<BonsaiDTO?> GetBonsaiByID(int id)
        {
            BonsaiDTO? bonsai = await _bonsaiRepo.GetBy(id);

            return bonsai is not null ? bonsai : null;
        }


        public async Task<IEnumerable<BonsaiDTO>?> GetBonsaiByName(string name)
        {
            return await _bonsaiRepo.GetBy(name);
        }


        public async Task<bool> UpdateBonsai(BonsaiDTO model)
        {
            return await _bonsaiRepo.Update(model);
        }


        public async Task<bool> DeleteBonsai(int id)
        {
            return await _bonsaiRepo.Delete(id);
        }


    }
}
