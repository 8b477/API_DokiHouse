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
    }
}
