using API_DokiHouse.Models;
using BLL_DokiHouse.Models;


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



        #region CATEGORY


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


        #endregion



        #region BONSAI


        /// <summary>
        /// Convertit un modèle de création de bonsaï en un objet de logique métier bonsaï.
        /// </summary>
        /// <param name="bonsai">Modèle de création de bonsaï à convertir.</param>
        /// <returns>Objet de logique métier bonsaï.</returns>
        public static BonsaiBLL BonsaiModelToBLL(BonsaiModel bonsai)
        {
            return new BonsaiBLL(bonsai.Name, bonsai.Description, 0);
        }


        #endregion


        #region STYLE

        public static StyleBLL StyleModelToBLL(StyleModel model)
        {
            return new StyleBLL(model.Bunjin, model.Bankan,model.Korabuki,model.Ishituki,model.Perso,0);
        }

        #endregion



        #region NOTE

        public static NoteBLL NoteModelToBLL(NoteModel model)
        {
            return new NoteBLL(model.Title, model.Description, DateTime.Now,0);
        }

        #endregion
    }
}
