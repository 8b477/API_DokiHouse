using BLL_DokiHouse.ExceptionHandler;
using BLL_DokiHouse.Interfaces;
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


        /// <summary>
        /// Récupère les user en base de donnée
        /// </summary>
        /// <returns>Retourne la liste des user</returns>
        public async Task<IEnumerable<UserDisplayDTO>> Get()
        {
            return await _userRepo.Get();     
        }


        /// <summary>
        /// Récupère un User sur base d'un identifiant
        /// </summary>
        /// <param name="id">identifiant de type 'int'</param>
        /// <returns>Retourne le User qui correspond a la recherche ou si non retourne null</returns>
        public async Task<UserDisplayDTO?> GetByID(int id)
        {
            UserDisplayDTO? result = await _userRepo.GetBy(id);

            if (result is not null)
                return result;

            return null;
        }


        /// <summary>
        /// Récupère un User sur base d'un identifiant
        /// </summary>
        /// <param name="id">identifiant de type 'string'</param>
        /// <returns>Retourne le User qui correspond a la recherche ou si non retourne null</returns>
        public async Task<IEnumerable<UserDisplayDTO>?> GetByName(string name)
        {
            IEnumerable<UserDisplayDTO>? result = await _userRepo.GetBy(name);

            if (result is not null)
                return result;

            return null;
        }


        /// <summary>
        /// Créer un nouveau utilisateur en base de donnée
        /// </summary>
        /// <param name="model">attend un : 'UserCreateDTO'</param>
        /// <returns>Retoune 'true' si réussi ou si non 'false'</returns>
        public async Task<bool> Create(UserCreateDTO model)
        {
            try
            {
                if (model is not null)
                    return await _userRepo.Create(model);

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


        /// <summary>
        /// Met à jour un user
        /// </summary>
        /// <param name="id">Identifiant de type 'int'</param>
        /// <param name="model">model de création attendu : 'UserCreateDTO'</param>
        /// <returns>Retourne le user modifié si réussi, si non retourne null</returns>
        public async Task<bool> Update(int id, UserCreateDTO model)
        {
            try
            {
               return await _userRepo.Update(id, model);
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

        public async Task<bool> Delete(int id)
        {
            return await _userRepo.Delete(id);
        }
    }
}
