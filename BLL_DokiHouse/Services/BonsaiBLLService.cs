using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Models;
using BLL_DokiHouse.Tools;
using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;
using DAL_DokiHouse.Repository;

namespace BLL_DokiHouse.Services
{
    public class BonsaiBLLService : IBonsaiBLLService
    {

        #region Injection

        private readonly IBonsaiRepo _bonsaiRepo;
        public BonsaiBLLService(IBonsaiRepo bonsaiRepo) => _bonsaiRepo = bonsaiRepo; 

        #endregion


        public async Task<bool> Create(BonsaiBLL model)
        {
            BonsaiCreateDTO bonsaiDTO = Mapper.BonsaiBLLToDAL(model);

            return await _bonsaiRepo.Create(bonsaiDTO);
        }


        public async Task<IEnumerable<BonsaiAndChild>?> Get()
        {
            return await _bonsaiRepo.GetAllBonsai();
        }


        public async Task<IEnumerable<BonsaiAndChild>> Get(int idUser)
        {
            return await _bonsaiRepo.GetAllBonsai(idUser);
        }


        public async Task<BonsaiDisplayDTO?> GetByID(int id)
        {
            return await _bonsaiRepo.GetBy(id);
        }


        public async Task<IEnumerable<BonsaiDisplayDTO>?> GetByName(string name)
        {
            return await _bonsaiRepo.GetBy(name);
        }


        public async Task<bool> Update(BonsaiDTO model)
        {
            return await _bonsaiRepo.UpdateBonsai(model);
        }


        public async Task<bool> Delete(int id)
        {
            return await _bonsaiRepo.Delete(id);
        }





        public Task<IEnumerable<BonsaiRepo.UserEveryDTO>?> GetTest()
        {
            return _bonsaiRepo.GetTest();
        }


    }
}
