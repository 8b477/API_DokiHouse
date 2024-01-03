using BLL_DokiHouse.ExceptionHandler;
using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Models;
using BLL_DokiHouse.Tools;

using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;

namespace BLL_DokiHouse.Services
{
    public class StyleBLLService : IStyleBLLService
    {

        #region Injection

        private readonly IStyleRepo _styleRepo;

        public StyleBLLService(IStyleRepo styleRepo) => _styleRepo = styleRepo;
        #endregion



        public async Task<bool> CreateStyle(StyleBLL style)
        {
            if (await _styleRepo.NotValide(style.IdBonsai))
                throw new BusinessException("Le Bonsai possède déjà un Style, update le !");

            StyleDTO styleDTO = Mapper.StyleBLLToDAL(style);

            return await _styleRepo.Create(styleDTO);
        }


        public async Task<bool> UpdateStyle(StyleBLL style)
        {
            StyleDTO styleDTO = Mapper.StyleBLLToDAL(style); 
            
            return await _styleRepo.Update(styleDTO);
        }



    }
}
