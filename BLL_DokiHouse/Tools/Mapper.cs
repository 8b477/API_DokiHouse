using BLL_DokiHouse.Models;

using DAL_DokiHouse.DTO;

using System.Collections.Generic;

namespace BLL_DokiHouse.Tools
{
    internal class Mapper
    {


        #region USER

        public static UserDTO UserBLLToDAL(UserBLL user)
        {
            return new UserDTO(user.Name, user.Email, user.Passwd, "Visitor");
        }

        public static UserUpNameDTO UserUpNameDTOBLLToDAL(int id, UserUpdateNameBLL user)
        {
            return new UserUpNameDTO(id, user.Name);
        }

        public static UserUpMailDTO UserUpMailDTOBLLToDAL(int id, UserUpdateMailBLL user)
        {
            return new UserUpMailDTO(id, user.Email);
        }

        public static UserUpPassDTO UserUpPassBLLToDAL(int id, UserUpdatePassBLL user)
        {
            return new UserUpPassDTO(id, user.Passwd);
        }

        public static UserBLL UserDALToBLL(UserDTO user)
        {
            return new UserBLL(user.Name, user.Email, user.Passwd, user.Role);
        }

        public static UserDTO UserUpdateBLLToDAL(UserUpdateBLL user)
        {
            return new(user.Name, user.Email, user.Passwd, user.Role);
        }

        #endregion



        #region BONSAI

        public static BonsaiDTO BonsaiBLLToDAL(BonsaiBLL bonsai)
        {
            return new BonsaiDTO(bonsai.Name, bonsai.Description, bonsai.IdUser);
        }

        #endregion



        #region CATEGORY

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
                style.Korabuki, style.Ishituki,
                style.Perso, style.IdBonsai
            );
        }

        #endregion



        #region NOTE

        public static NoteDTO NoteBLLToDAL(NoteBLL model)
        {
            return new NoteDTO(model.Title, model.Description, model.CreateAt, model.IdBonsai);
        }

        #endregion


        #region POST

        public static PostDTO PostBLLToDAL(PostBLL post)
        {
            return new(post.Title, post.Description, post.Content, post.CreateAt,post.IdUser);
        }

        #endregion


        #region COMMENTS

        public static CommentsDTO CommentBLLToDAL(CommentBLL comment)
        {
            return new(comment.Content, comment.CreatedAt, comment.IdUser);
        }

        #endregion
    }
}
