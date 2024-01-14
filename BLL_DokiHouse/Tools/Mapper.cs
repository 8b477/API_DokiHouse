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
            return new UserDTO(user.Name, user.Email, user.Passwd, DateTime.Now, DateTime.Now, "Visitor");
        }

        public static UserUpNameDTO UserUpNameDTOBLLToDAL(int id, UserUpdateNameBLL user)
        {
            return new UserUpNameDTO(id, user.Name, DateTime.Now);
        }

        public static UserUpMailDTO UserUpMailDTOBLLToDAL(int id, UserUpdateMailBLL user)
        {
            return new UserUpMailDTO(id, user.Email, DateTime.Now);
        }

        public static UserUpPassDTO UserUpPassBLLToDAL(int id, UserUpdatePassBLL user)
        {
            return new UserUpPassDTO(id, user.Passwd, DateTime.Now);
        }

        //public static UserBLL UserDALToBLL(UserDTO user)
        //{
        //    return new UserBLL(user.Name, user.Email, user.Passwd, user.Role);
        //}

        public static UserDTO UserUpdateBLLToDAL(UserUpdateBLL user)
        {
            return new(user.Name, user.Email, user.Passwd, user.Role, DateTime.Now);
        }

        #endregion



        #region BONSAI

        public static BonsaiDTO BonsaiBLLToDAL(BonsaiBLL bonsai)
        {
            return new BonsaiDTO(bonsai.Name, bonsai.Description, DateTime.Now, DateTime.Now, bonsai.IdUser);
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
                cate.Perso, DateTime.Now, DateTime.Now, cate.IdBonsai
            );
        }

        #endregion



        #region STYLE

        public static StyleDTO StyleBLLToDAL(StyleBLL style)
        {
            return new StyleDTO(
                style.Bunjin, style.Bankan,
                style.Korabuki, style.Ishituki,
                style.Perso,DateTime.Now,DateTime.Now, style.IdBonsai
            );
        }

        #endregion



        #region NOTE

        public static NoteDTO NoteBLLToDAL(NoteBLL model)
        {
            return new NoteDTO(model.Title, model.Description, DateTime.Now,DateTime.Now, model.IdBonsai);
        }

        #endregion


        #region POST

        public static PostDTO PostBLLToDAL(PostBLL post)
        {
            return new() { Title = post.Title, Description = post.Description,Content = post.Content, CreateAt = DateTime.Now, ModifiedAt = DateTime.Now, IdUser = post.IdUser };
        }

        #endregion


        #region COMMENTS

        public static CommentsDTO CommentBLLToDAL(CommentBLL comment)
        {
            return new(comment.Content, DateTime.Now, DateTime.Now, comment.IdUser,comment.IdPost);
        }

        #endregion
    }
}
