using DAL_DokiHouse.DTO;

namespace API_DokiHouse.Services
{
    public static class Mapper
    {
        public static UserCreateDTO FromConfirmPassToModelCreate(UserCreateDTOPassConfirm user)
        {
            return new UserCreateDTO()
            {
                Email = user.Email,
                Passwd = user.Passwd,
                Name = user.Name
            };
        }

        public static UserCreateDTO FromUpdateToModelCreate(UserUpdateDTO user)
        {
            return new UserCreateDTO()
            {
                Email = user.Email,
                Passwd = user.Passwd,
                Name = user.Name
            };
        }
    }
}