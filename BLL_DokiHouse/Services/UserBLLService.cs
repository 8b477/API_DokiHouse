using BCrypt.Net;
using BLL_DokiHouse.ExceptionHandler;
using BLL_DokiHouse.Extensions;
using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Models.User;
using BLL_DokiHouse.Models.User.View;
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



        #region  ========> _______________GET________________ <==========

        public async Task<IEnumerable<UserAndPictureDTO>> GetUsers(int startIndex, int pageSize)
        {
            return await _userRepo.GetUsers(startIndex, pageSize);
        }


        public async Task<UserAndPictureDTO?> GetUser(int idUser)
        {
            return await _userRepo.GetUser(idUser);
        }


        public async Task<User?> GetUserByID(int id)
        {
            User? result = await _userRepo.GetBy(id);

            if (result is not null)
                return result;

            return null;
        }


        public async Task<IEnumerable<User?>?> GetUsersByName(string name, string stringIdentifiant)
        {
            IEnumerable<User>? result = await _userRepo.GetBy(name, stringIdentifiant);

            if (result is not null)
                return result;

            return null;
        }

        #endregion




        #region  ========> ______________CREATE______________ <==========

        public async Task<UserView?> CreateUser(UserCreateModel model)
        {
            try
            {
                if (model is not null)
                {
                    model.Passwd = BCrypt.Net.BCrypt.HashPassword(model.Passwd);

                    User user = Mapping.UserCreateBLLToDAL(model);

                    if( await _userRepo.Create(user) )
                        return user.BLLToView();
                }
                return null;
            }

            catch (SqlException ex) when (ex.Number == 2627)
            {
                throw new BusinessException("Adresse mail invalide !");
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion





        #region  ========> _______________LOGIN________________ <==========

        public async Task<User?> Login(string email, string passwd)
        {
            try
            {
                User? user = await _userRepo.Logger(email, passwd);

                return user is not null
                       ? user
                       : null;
            }
            catch (SaltParseException)
            {
                throw new SaltParseException("Informations invalide !");
            }
        }


        #endregion





        #region  ========> _______________UPDATE________________ <==========

        public Task<bool> UpdateUser(int id, UserUpdateModel model)
        {
            User user = Mapping.UserUpdateBLLToDAL(model);

            user.Passwd = BCrypt.Net.BCrypt.HashPassword(model.Passwd);

            try
            {
                return _userRepo.Update(id, user);
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                throw new BusinessException("Le mail n'est pas valide !");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<bool> UpdateUserName(int id, UserUpdateNameModel model)
        {
            User user = Mapping.UserUpdateNameBLLToDAL(model);

            return await _userRepo.UpdateName(id, user);             
        }


        public async Task<bool> UpdateUserPass(int id, UserUpdatePasswdModel model)
        {
            User user = Mapping.UserUpdatePassBLLToDAL(model);

            user.Passwd = BCrypt.Net.BCrypt.HashPassword(model.Passwd);

            return await _userRepo.UpdatePass(id, user);
        }


        public async Task<bool> UpdateUserEmail(int id, UserUpdateEmailModel model)
        {
            try
            {
                User user = Mapping.UserUpdateEmailBLLToDAL(model);

                return await _userRepo.UpdateEmail(id, user);
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                throw new BusinessException("Adresse mail invalide");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //public Task<bool> UpdateProfilPicture(int idPicture, int idUser)
        //{
        //    return _userRepo.UpdateProfilPicture(idPicture, idUser);
        //}


        #endregion




        #region  ========> ______________DELETE_______________ <==========

        public async Task<bool> DeleteUser(int id)
        {
            return await _userRepo.Delete(id);
        }

        #endregion

    }
}
