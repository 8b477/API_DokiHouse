using API_DokiHouse.Models;

using DAL_DokiHouse.DTO;

using static API_DokiHouse.Models.BonsaiModel;

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

        public static BonsaiCreateDTO FromBonsaiCreateModelToBonsaiCreateDTO(BonsaiCreateModel bonsai)
        {
            return new BonsaiCreateDTO(bonsai.Name, bonsai.Description);
        }
    }
}
