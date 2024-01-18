using API_DokiHouse.Models;
using BLL_DokiHouse.ExceptionHandler;
using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Tools;
using DAL_DokiHouse.Interfaces;
using Entities_DokiHouse.Entities;


namespace BLL_DokiHouse.Services
{
    public class StyleBLLService : IStyleBLLService
    {

        #region Injection

        private readonly IStyleRepo _styleRepo;

        public StyleBLLService(IStyleRepo styleRepo) => _styleRepo = styleRepo;
        #endregion



        public async Task<bool> CreateStyle(int idBonsai, StyleModel style)
        {
            if (await _styleRepo.IsAlreadyExists(idBonsai))
                throw new BusinessException("Le Bonsai possède déjà un Style, update le !");

            Style styleDAL = Mapping.StyleCreateBLLToDAL(style);

            return await _styleRepo.Create(idBonsai, styleDAL);
        }


        public async Task<bool> UpdateStyle(int idStyle, StyleModel style)
        {
            Style styleDAL = Mapping.StyleUpdateBLLToDAL(style);

            return await _styleRepo.Update(idStyle, styleDAL);
        }


        public async Task<bool> DeleteStyle(int idStyle)
        {
            return await _styleRepo.Delete(idStyle);
        }

    }
}
