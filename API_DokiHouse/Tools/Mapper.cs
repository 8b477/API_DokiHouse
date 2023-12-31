using API_DokiHouse.Models;
using DAL_DokiHouse.DTO;

namespace API_DokiHouse.Services
{
    public static class Mapper
    {
        public static UserCreateDTO FromConfirmPassToModelCreate(UserPassConfirmModel user)
        {
            return new UserCreateDTO(user.Name, user.Email, user.Passwd);
        }

        public static UserCreateDTO FromUpdateToModelCreate(UserUpdateModel user)
        {
            return new UserCreateDTO(user.Name, user.Email, user.Passwd);
        }

        public static CategoryDTO FromCategoryModelToCategoryDTO(CategoryModel user)
        {
            return new CategoryDTO(
                        user.Id,
                        user.Shohin, user.Mame, user.Chokkan,
                        user.Moyogi,user.Shakan, user.Kengai,
                        user.HanKengai, user.Ikadabuki, user.Neagari,
                        user.Literati, user.YoseUe, user.Ishitsuki,
                        user.Kabudachi, user.Kokufu, user.Yamadori,
                        user.Perso, user.IdBonsai
                        );
        }
    }
}
