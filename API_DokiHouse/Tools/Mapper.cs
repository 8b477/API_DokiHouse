using DAL_DokiHouse.DTO;

using System.Xml.Linq;

namespace API_DokiHouse.Services
{
    public static class Mapper
    {
        public static UserCreateDTO FromConfirmPassToModelCreate(UserCreateDTOPassConfirm user)
        {
            return new UserCreateDTO(user.Email, user.Passwd, user.Name);
        }

        public static UserCreateDTO FromUpdateToModelCreate(UserUpdateDTO user)
        {
            return new UserCreateDTO(user.Email, user.Passwd, user.Name);
        }
    }
}
