using BLL_DokiHouse.ExceptionHandler;
using BLL_DokiHouse.Interfaces;
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


        /// <summary>
        /// Met à jour l'ID de l'image de profil pour un utilisateur spécifié.
        /// </summary>
        /// <param name="idPicture">L'ID de l'image de profil à associer à l'utilisateur.</param>
        /// <param name="idUser">L'ID de l'utilisateur dont l'image de profil doit être mise à jour.</param>
        /// <returns>Une tâche représentant l'opération de mise à jour.</returns>
        public Task<bool> UpdateProfilPicture(int idPicture, int idUser)
        {
            return _userRepo.UpdateProfilPicture(idPicture, idUser);
        }


        /// <summary>
        /// Supprime un élément sur base d'un identifiant
        /// </summary>
        /// <param name="id">Un identifiant de type : int</param>
        /// <returns>Retourne true si l'item à bien été supprimer de la base de donnée dans le cas contraire retourne false</returns>
        public async Task<bool> Delete(int id)
        {
            return await _userRepo.Delete(id);
        }


        /// <summary>
        /// Vérifie si un User est présent en base de donnée sur base de mot de passe et email
        /// </summary>
        /// <param name="email">Attendue emai de type : string</param>
        /// <param name="passwd">Attendue mot de passe de type : string</param>
        /// <returns></returns>
        public async Task<User?> Login(string email, string passwd)
        {
            User? user = await _userRepo.Logger(email,passwd);

            return user is not null ? user : null;
        }

    }
}
