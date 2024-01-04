using BLL_DokiHouse.ExceptionHandler;
using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Models;
using BLL_DokiHouse.Tools;
using DAL_DokiHouse;
using DAL_DokiHouse.DTO;

using System.Data.SqlClient;

namespace BLL_DokiHouse.Services
{
    public class UserBLLService : IUserBLLService
    {

        #region Injection
        private readonly IUserRepo _userRepo;

        public UserBLLService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        #endregion


        public async Task<IEnumerable<UserDTO>> Get()
        {
            return await _userRepo.Get();
        }



        public async Task<UserDTO?> GetByID(int id)
        {
            UserDTO? result = await _userRepo.GetBy(id);

            if (result is not null)
                return result;

            return null;
        }



        public async Task<IEnumerable<UserDTO>?> GetByName(string name)
        {
            IEnumerable<UserDTO>? result = await _userRepo.GetBy(name);

            if (result is not null)
                return result;

            return null;
        }



        public async Task<bool> CreateUser(UserBLL model)
        {
            try
            {
                if (model is not null)
                {
                    model.Passwd = BCrypt.Net.BCrypt.HashPassword(model.Passwd);
                    
                    UserDTO user = Mapper.UserBLLToDAL(model);

                    return await _userRepo.Create(user);
                }

                return false;
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                    throw new BusinessException("L'adresse mail existe déjà en base de donnée");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<bool> UpdateUser(int id, UserBLL model)
        {
            try
            {
               model.Passwd = BCrypt.Net.BCrypt.HashPassword(model.Passwd);

               UserDTO user = Mapper.UserBLLToDAL(model);

                user.Id = id;

               return await _userRepo.Update(user);
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                throw new BusinessException("L'adresse mail existe déjà en base de donnée");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }          
        }



        public async Task<bool> DeleteUser(int id)
        {
            return await _userRepo.Delete(id);
        }



        public async Task<UserDTO?> Login(string email, string passwd)
        {
            UserDTO? user = await _userRepo.Logger(email, passwd);

            return
                user is not null
                ? user 
                : null;
        }



        public Task<bool> UpdateProfilPicture(int idPicture, int idUser)
        {
            return _userRepo.UpdateProfilPicture(idPicture, idUser);
        }
    }
}
