using API_DokiHouse.Models;
using BLL_DokiHouse.ExceptionHandler;
using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Tools;
using DAL_DokiHouse.Interfaces;
using Entities_DokiHouse.Entities;


namespace BLL_DokiHouse.Services
{
    public class CategoryBLLService : ICategoryBLLService
    {

        #region Injection
        private readonly ICategoryRepo _repoCategory;

        public CategoryBLLService(ICategoryRepo repoCategory) => _repoCategory = repoCategory;
        #endregion


        public async Task<bool> CreateCategory(int idBonsai, CategoryModel model)
        {
            if (await _repoCategory.IsAlreadyExists(idBonsai))
                throw new BusinessException("Le Bonsai possède déjà une Catégorie, update le !");

            Category category =  Mapping.CategoryCreateBLLToDAL(model);

            return await _repoCategory.Create(category, idBonsai);
        }


        public async Task<bool> UpdateCategory(CategoryModel model, int idCategory)
        {
            Category category = Mapping.CategoryUpdateBLLToDAL(model);

            return await _repoCategory.Update(idCategory, category);
        }


        public async Task<bool> DeleteCategory(int idCategory)
        {
            return await _repoCategory.Delete(idCategory);
        }
    }
}
