using BLL_DokiHouse.Models;
using DAL_DokiHouse.DTO;

namespace BLL_DokiHouse.Tools
{
    internal class Mapper
    {
        public static CategoryDTO CategoryBLLToDAL(CategoryBLL cate)
        {
            return new CategoryDTO(
                        cate.Shohin,cate.Mame,cate.Chokkan,
                        cate.Moyogi,cate.Shakan,cate.Kengai,
                        cate.HanKengai, cate.Ikadabuki, cate.Neagari,
                        cate.Literati,cate.YoseUe, cate.Ishitsuki,
                        cate.Kabudachi, cate.Kokufu, cate.Yamadori,
                        cate.Perso,cate.IdBonsai
                        );
        }

        public static UserCreateDTO UserBLLToDAL(UserBLL user)
        {
            return new UserCreateDTO(user.Name,user.Email, user.Passwd);
        }

        public static BonsaiCreateDTO BonsaiBLLToDAL(BonsaiBLL bonsai)
        {
            return new BonsaiCreateDTO(bonsai.Name, bonsai.Description, bonsai.IdUser);
        }
    }
}
