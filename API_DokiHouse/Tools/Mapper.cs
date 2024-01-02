using API_DokiHouse.Models;
using BLL_DokiHouse.Models;

using static API_DokiHouse.Models.BonsaiModel;

namespace API_DokiHouse.Services
{
    internal static class Mapper
    {

        #region USER


        /// <summary>
        /// Convertit un modèle de création d'utilisateur en un objet de logique métier utilisateur.
        /// </summary>
        /// <param name="user">Modèle de création d'utilisateur à convertir.</param>
        /// <returns>Objet de logique métier utilisateur.</returns>
        public static UserBLL UserModelToBLL(UserCreateModel user)
        {
            return new UserBLL(user.Name, user.Email, user.Passwd);
        }


        /// <summary>
        /// Convertit un modèle de mise à jour d'utilisateur en un objet de logique métier utilisateur.
        /// </summary>
        /// <param name="user">Modèle de mise à jour d'utilisateur à convertir.</param>
        /// <returns>Objet de logique métier utilisateur.</returns>
        public static UserBLL UserModelToBLL(UserUpdateModel user)
        {
            return new UserBLL(user.Name, user.Email, user.Passwd);
        }


        #endregion


        #region BONSAI


        /// <summary>
        /// Convertit un modèle de catégorie en un objet de logique métier catégorie.
        /// </summary>
        /// <param name="user">Modèle de catégorie à convertir.</param>
        /// <returns>Objet de logique métier catégorie.</returns>
        public static CategoryBLL CategoryModelToBLL(CategoryModel user)
        {
            return new CategoryBLL(
                user.Shohin, user.Mame, user.Chokkan,
                user.Moyogi, user.Shakan, user.Kengai,
                user.HanKengai, user.Ikadabuki, user.Neagari,
                user.Literati, user.YoseUe, user.Ishitsuki,
                user.Kabudachi, user.Kokufu, user.Yamadori,
                user.Perso, 0
            );
        }


        /// <summary>
        /// Convertit un modèle de création de bonsaï en un objet de logique métier bonsaï.
        /// </summary>
        /// <param name="bonsai">Modèle de création de bonsaï à convertir.</param>
        /// <returns>Objet de logique métier bonsaï.</returns>
        public static BonsaiBLL BonsaiModelToBLL(BonsaiCreateModel bonsai)
        {
            return new BonsaiBLL(bonsai.Name, bonsai.Description, 0);
        }


        #endregion
    }
}
