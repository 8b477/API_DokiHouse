using BLL_DokiHouse.ExceptionHandler;
using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Models;
using BLL_DokiHouse.Tools;

using DAL_DokiHouse;
using DAL_DokiHouse.DTO;
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


        public async Task<IEnumerable<UserDisplayDTO>> Get()
        {
            return await _userRepo.Get();     
        }



        public async Task<UserDisplayDTO?> GetByID(int id)
        {
            UserDisplayDTO? result = await _userRepo.GetBy(id);

            if (result is not null)
                return result;

            return null;
        }



        public async Task<IEnumerable<UserDisplayDTO>?> GetByName(string name)
        {
            IEnumerable<UserDisplayDTO>? result = await _userRepo.GetBy(name);

            if (result is not null)
                return result;

            return null;
        }



        public async Task<bool> Create(UserBLL model)
        {
            try
            {
                if (model is not null)
                {
                    UserCreateDTO user = new(model.Name, model.Email, BCrypt.Net.BCrypt.HashPassword(model.Passwd));

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



        public async Task<bool> Update(int id, UserBLL model)
        {
            try
            {
               UserCreateDTO userDTO = Mapper.UserBLLToDAL(model);

               userDTO.Passwd = BCrypt.Net.BCrypt.HashPassword(model.Passwd);

               return await _userRepo.Update(id, userDTO);
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



        public Task<bool> UpdateProfilPicture(int idPicture, int idUser)
        {
            return _userRepo.UpdateProfilPicture(idPicture, idUser);
        }



        public async Task<bool> Delete(int id)
        {
            return await _userRepo.Delete(id);
        }



        public async Task<User?> Login(string email, string passwd)
        {
            User? user = await _userRepo.Logger(email,passwd);

            return user is not null ? user : null;
        }


        public async Task<IEnumerable<UserRepo.UserEveryDTO>?> GetEvery()
        {
            return await _userRepo.GetEvery();
        }


    }
}
