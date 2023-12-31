﻿using BLL_DokiHouse.Interfaces;
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


        public async Task<bool> Update(CategoryDTO model)
        {
            return await _repoCategory.Update(model);
        }


        public async Task<bool> Create(CategoryDTO model)
        {
            return await _repoCategory.Create(model);
        }
    }
}