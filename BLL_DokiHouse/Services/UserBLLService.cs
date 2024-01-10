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


        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            return await _userRepo.Get();
        }


        public async Task<UserDTO?> GetUserByID(int id)
        {
            UserDTO? result = await _userRepo.GetBy(id);

            if (result is not null)
                return result;

            return null;
        }


        public async Task<IEnumerable<UserDTO>?> GetUsersByName(string name, string stringIdentifiant)
        {
            IEnumerable<UserDTO>? result = await _userRepo.GetBy(name, stringIdentifiant);

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


        public async Task<bool> UpdateUserName(int id, UserUpdateNameBLL model)
        {
            UserUpNameDTO user = Mapper.UserUpNameDTOBLLToDAL(id,model);

            return await _userRepo.UpdateName(user);             
        }


        public async Task<bool> UpdateUserPass(int id, UserUpdatePassBLL model)
        {
            model.Passwd = BCrypt.Net.BCrypt.HashPassword(model.Passwd);

            UserUpPassDTO user = Mapper.UserUpPassBLLToDAL(id, model);

            return await _userRepo.UpdatePass(user);
        }


        public async Task<bool> UpdateUserEmail(int id, UserUpdateMailBLL model)
        {
            try
            {
                UserUpMailDTO user = Mapper.UserUpMailDTOBLLToDAL(id, model);

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


        public async Task<UserDTO?> Login(string email, string passwd)
        {
            UserDTO? user = await _userRepo.Logger(email, passwd);

            return
                user is not null
                ? user 
                : null;
        }


        public Task<bool> UpdateUser(int id,  UserUpdateBLL model)
        {
            UserDTO userDTO = Mapper.UserUpdateBLLToDAL(model);

            return _userRepo.Update(userDTO);
        }
    }
}
