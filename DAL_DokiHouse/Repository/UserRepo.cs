using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Repository;
using Entities_DokiHouse;

using System.Data;


namespace DAL_DokiHouse
{
    public class UserRepo : BaseRepo<User, UserDTO, UserCreateDTO, UserDisplayDTO, int, string>, IUserRepo
    {

        #region Constructor

        public UserRepo(IDbConnection connection) : base(connection) { }

        #endregion


        public Task<UserDTO?> Logger(string email, string motDePasse)
        {
            throw new NotImplementedException();
        }

    }
}
