using API_DokiHouse.Models;
using BLL_DokiHouse.Models;

using static API_DokiHouse.Models.BonsaiModel;

namespace API_DokiHouse.Services
{
    public static class Mapper
    {
        

        // User
        public static UserBLL UserModelToBLL(UserCreateModel user)
        {
            return new UserBLL(user.Name, user.Email, user.Passwd);
        }

        public static UserBLL UserModelToBLL(UserUpdateModel user)
        {
            return new UserBLL(user.Name, user.Email, user.Passwd);
        }


        // Category
        public static CategoryBLL CategoryModelToBLL(CategoryModel user)
        {
            return new CategoryBLL(
                        user.Shohin, user.Mame, user.Chokkan,
                        user.Moyogi, user.Shakan, user.Kengai,
                        user.HanKengai, user.Ikadabuki, user.Neagari,
                        user.Literati, user.YoseUe, user.Ishitsuki,
                        user.Kabudachi, user.Kokufu, user.Yamadori,
                        user.Perso,0
                        );
        }


        //Bonsai
        public static BonsaiBLL BonsaiModelToBLL(BonsaiCreateModel bonsai)
        {
            return new BonsaiBLL(bonsai.Name, bonsai.Description,0);
        }
    }
}
