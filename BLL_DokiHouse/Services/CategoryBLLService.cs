using BLL_DokiHouse.ExceptionHandler;
using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Models;
using BLL_DokiHouse.Tools;

using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;

namespace BLL_DokiHouse.Services
{
    public class CategoryBLLService : ICategoryBLLService
    {

        #region Injection
        private readonly ICategoryRepo _repoCategory;

        public CategoryBLLService(ICategoryRepo repoCategory) => _repoCategory = repoCategory;
        #endregion


        public async Task<bool> UpdateCategory(CategoryBLL model)
        {
            CategoryDTO categoryDTO = Mapper.CategoryBLLToDAL(model); 

            return await _repoCategory.Update(categoryDTO);
        }


        public async Task<bool> CreateCategory(int idBonsai, CategoryBLL model)
        {
            if (await _repoCategory.NotValide(model.IdBonsai))
                throw new BusinessException("Le Bonsai possède déjà une Catégorie, update le !");

            CategoryDTO categoryDAL = Mapper.CategoryBLLToDAL(model);

            return await _repoCategory.Create(categoryDAL);
        }

    }
}
