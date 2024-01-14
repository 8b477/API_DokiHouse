using API_DokiHouse.Models;

using Entities_DokiHouse.Entities;

namespace BLL_DokiHouse.Tools
{
    internal class Mapping
    {

        #region Bonsai

        public static Bonsai BonsaiCreateBLLtoDAL(BonsaiModel bonsaiBLL)
        {
            return new() 
            {
                Name = bonsaiBLL.Name,
                CreatedAt = DateTime.Now,
                Description = bonsaiBLL.Description
            };
        }

        public static Bonsai BonsaiUpdateBLLtoDAL(BonsaiModel bonsaiBLL)
        {
            return new()
            {
                Name = bonsaiBLL.Name,
                ModifiedAt = DateTime.Now,
                Description = bonsaiBLL.Description
            };
        }

        #endregion


        #region User


        #endregion
    }
}
