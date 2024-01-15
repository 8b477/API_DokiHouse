using BLL_DokiHouse.ExceptionHandler;
using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Models.User;
using BLL_DokiHouse.Tools;
using DAL_DokiHouse;
using DAL_DokiHouse.DTO.User;
using Entities_DokiHouse.Entities;
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


        public async Task<User?> GetUserByID(int id)
        {
            User? result = await _userRepo.GetBy(id);

            if (result is not null)
                return result;

            return null;
        }


        public async Task<IEnumerable<User>?> GetUsersByName(string name, string stringIdentifiant)
        {
            IEnumerable<User>? result = await _userRepo.GetBy(name, stringIdentifiant);

            if (result is not null)
                return result;

            return null;
        }


        public async Task<bool> CreateUser(UserCreateModel model)
        {
            try
            {
                if (model is not null)
                {
                    model.Passwd = BCrypt.Net.BCrypt.HashPassword(model.Passwd);

                    User user = Mapping.UserCreateBLLToDAL(model);
                    
                    return await _userRepo.Create(user);
                }

                return false;
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                throw new BusinessException("Le mail existe déjà en base de donnée !");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<bool> UpdateUserName(int id, UserUpdateModel model)
        {
            User user = Mapping.UserUpdateBLLToDAL(model);

            return await _userRepo.UpdateName(user);             
        }


        public async Task<bool> UpdateUserPass(int id, UserUpdateModel model)
        {
            User user = Mapping.UserUpdateBLLToDAL(model);

            user.Passwd = BCrypt.Net.BCrypt.HashPassword(model.Passwd);

            return await _userRepo.UpdatePass(user);
        }


        public async Task<bool> UpdateUserEmail(int id, UserUpdateModel model)
        {
            try
            {
                User user = Mapping.UserUpdateBLLToDAL(model);

                return await _userRepo.UpdateEmail(user);
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


        public Task<bool> UpdateProfilPicture(int idPicture, int idUser)
        {
            return _userRepo.UpdateProfilPicture(idPicture, idUser);
        }


        public async Task<User?> Login(string email, string passwd)
        {
            User? user = await _userRepo.Logger(email, passwd);

            return
                user is not null
                ? user 
                : null;
        }


        public Task<bool> UpdateUser(int id,  UserUpdateModel model)
        {
            User user = Mapping.UserUpdateBLLToDAL(model);

            return _userRepo.Update(user);
        }


        public Task<IEnumerable<UserAndBonsaiDetails?>> GetInfos(int startIndex, int pageSize)
        {
            return _userRepo.GetInfos(startIndex, pageSize);
        }


        public Task<UserAndBonsaiDetails?> GetInfosById(int idUser)
        {
            return _userRepo.GetInfosById(idUser);
        }


        public async Task<IEnumerable<UserAndPictureDTO>> GetUsers(int startIndex, int pageSize)
        {
            return await _userRepo.GetUsers(startIndex, pageSize);
        }
    }
}
