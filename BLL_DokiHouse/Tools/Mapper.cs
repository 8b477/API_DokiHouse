using BLL_DokiHouse.Models;

using DAL_DokiHouse.DTO;

using System.Collections.Generic;

namespace BLL_DokiHouse.Tools
{
    internal class Mapper
    {


        #region USER



        /// <summary>
        /// Convertit un objet de logique métier utilisateur en un objet d'accès aux données pour la création d'utilisateur.
        /// </summary>
        /// <param name="user">Objet de logique métier utilisateur à convertir.</param>
        /// <returns>Objet d'accès aux données pour la création d'utilisateur.</returns>
        public static UserDTO UserBLLToDAL(UserBLL user)
        {
            return new UserDTO(user.Name,user.Email, user.Passwd, "Visitor");
        }


        public static UserBLL UserDALToBLL(UserDTO user)
        {
            return new UserBLL(user.Name, user.Email, user.Passwd);
        }


        #endregion



        #region BONSAI

        /// <summary>
        /// Convertit un objet de logique métier bonsaï en un objet d'accès aux données pour la création de bonsaï.
        /// </summary>
        /// <param name="bonsai">Objet de logique métier bonsaï à convertir.</param>
        /// <returns>Objet d'accès aux données pour la création de bonsaï.</returns>
        public static BonsaiDTO BonsaiBLLToDAL(BonsaiBLL bonsai)
        {
            return new BonsaiDTO(bonsai.Name, bonsai.Description, bonsai.IdUser);
        }


        #endregion



        #region CATEGORY


        /// <summary>
        /// Convertit un objet de logique métier catégorie en un objet d'accès aux données catégorie.
        /// </summary>
        /// <param name="cate">Objet de logique métier catégorie à convertir.</param>
        /// <returns>Objet d'accès aux données catégorie.</returns>
        public static CategoryDTO CategoryBLLToDAL(CategoryBLL cate)
        {
            return new CategoryDTO(
                        cate.Shohin, cate.Mame, cate.Chokkan,
                        cate.Moyogi, cate.Shakan, cate.Kengai,
                        cate.HanKengai, cate.Ikadabuki, cate.Neagari,
                        cate.Literati, cate.YoseUe, cate.Ishitsuki,
                        cate.Kabudachi, cate.Kokufu, cate.Yamadori,
                        cate.Perso, cate.IdBonsai
                        );
        }

        #endregion



        #region STYLE

        public static StyleDTO StyleBLLToDAL(StyleBLL style)
        {
            return new StyleDTO(
                         style.Bunjin, style.Bankan,
                         style.Korabuki,style.Ishituki,
                         style.Perso,style.IdBonsai
                         );
        }

        #endregion



        #region NOTE

        public static NoteDTO NoteBLLToDAL(NoteBLL model)
        {
            return new NoteDTO(model.Title, model.Description, model.CreateAt, model.IdBonsai);
        }

        #endregion

    }
}
