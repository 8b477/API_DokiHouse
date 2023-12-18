using DAL_DokiHouse.DTO;

namespace API_DokiHouse.Services
{
    public static class Mapper
    {
        public static UserCreateDTO ToModelCreate(UserCreateDTOPassConfirm user)
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
