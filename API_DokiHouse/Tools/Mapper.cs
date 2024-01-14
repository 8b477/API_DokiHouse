using API_DokiHouse.Models;
using BLL_DokiHouse.Models;

using DAL_DokiHouse.DTO;

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
            return new UserBLL(user.Name, user.Email, user.Passwd, "Visitor");
        }


        /// <summary>
        /// Convertit un modèle de création d'utilisateur en un objet de logique métier utilisateur.
        /// </summary>
        /// <param name="user">Modèle de création d'utilisateur à convertir.</param>
        /// <returns>Objet de logique métier utilisateur.</returns>
        public static UserUpdateBLL UserUpdateModelToBLL(UserUpdateModel user)
        {
            return new UserUpdateBLL(user.Name, user.Email, user.Passwd, user.Role);
        }


        /// <summary>
        /// Convertit un modèle de mise à jour d'utilisateur en un objet de logique métier utilisateur.
        /// </summary>
        /// <param name="user">Modèle de mise à jour d'utilisateur à convertir.</param>
        /// <returns>Objet de logique métier utilisateur.</returns>
        public static UserUpdateNameBLL UserModelToBLL(UserNameUpdateModel user)
        {
            return new UserUpdateNameBLL(user.Name);
        }


        /// <summary>
        /// Convertit un modèle de mise à jour d'utilisateur en un objet de logique métier utilisateur.
        /// </summary>
        /// <param name="user">Modèle de mise à jour d'utilisateur à convertir.</param>
        /// <returns>Objet de logique métier utilisateur.</returns>
        public static UserUpdatePassBLL UserModelToBLL(UserPassUpdateModel user)
        {
            return new UserUpdatePassBLL(user.Passwd);
        }



        /// <summary>
        /// Convertit un modèle de mise à jour d'utilisateur en un objet de logique métier utilisateur.
        /// </summary>
        /// <param name="user">Modèle de mise à jour d'utilisateur à convertir.</param>
        /// <returns>Objet de logique métier utilisateur.</returns>
        public static UserUpdateMailBLL UserModelToBLL(UserMailUpdateModel user)
        {
            return new UserUpdateMailBLL(user.Email);
        }


        /// <summary>
        /// Convertit une liste d'objets de logique métier utilisateur en une liste de modèles d'affichage utilisateur.
        /// </summary>
        /// <param name="users">Liste d'objets de logique métier utilisateur à convertir.</param>
        /// <returns>Liste de modèles d'affichage utilisateur.</returns>
        public static IEnumerable<UserModelDisplay> UserBLLToFormatDisplay(IEnumerable<UserDTO> users)
        {
            List<UserModelDisplay> usersCollection = new();

            foreach (var item in users)
            {
                UserModelDisplay userDisplay = new(item.Id, item.Name, item.Role);

                usersCollection.Add(userDisplay);
            }

            return usersCollection;
        }


        /// <summary>
        /// Convertit un objet de logique métier utilisateur en un modèle d'affichage utilisateur.
        /// </summary>
        /// <param name="user">Objet de logique métier utilisateur à convertir.</param>
        /// <returns>Modèle d'affichage utilisateur.</returns>
        public static UserModelDisplay UserBLLToFormatDisplay(UserDTO user)
        {
            return new UserModelDisplay(user.Id, user.Name, user.Role);
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

        /// <summary>
        /// Convertit un modèle de style en un objet de logique métier style.
        /// </summary>
        /// <param name="model">Modèle de style à convertir.</param>
        /// <returns>Objet de logique métier style.</returns>
        public static StyleBLL StyleModelToBLL(StyleModel model)
        {
            return new StyleBLL(model.Bunjin, model.Bankan, model.Korabuki, model.Ishituki, model.Perso, 0);
        }

        #endregion


        #region NOTE

        /// <summary>
        /// Convertit un modèle de note en un objet de logique métier note.
        /// </summary>
        /// <param name="model">Modèle de note à convertir.</param>
        /// <returns>Objet de logique métier note.</returns>
        public static NoteBLL NoteModelToBLL(NoteModel model)
        {
            return new NoteBLL(model.Title, model.Description, 0);
        }

        #endregion


        #region POST

        public static PostBLL PostModelToPostBLL(PostModel post)
        {
            return new PostBLL(post.Title, post.Description, post.Content,  0);
        }

        #endregion


        #region COMMENTS

        public static CommentBLL CommentModelToCommentBLL(CommentModel comment)
        {
            return new CommentBLL(comment.Content, DateTime.Now,0,0);
        }

        #endregion
    }
}