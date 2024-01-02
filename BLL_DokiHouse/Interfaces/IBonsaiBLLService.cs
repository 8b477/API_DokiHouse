using BLL_DokiHouse.Models;

using DAL_DokiHouse.DTO;

namespace BLL_DokiHouse.Interfaces
{
    public interface IBonsaiBLLService
    {

        /// <summary>
        /// Crée un nouveau bonsaï.
        /// </summary>
        /// <param name="model">Le modèle de bonsaï à créer.</param>
        /// <returns>L'ID du bonsaï créé.</returns>
        Task<bool> Create(BonsaiBLL model);

        /// <summary>
        /// Récupère tous les bonsaïs avec leurs informations associées.
        /// </summary>
        /// <returns>Une collection de bonsaïs avec leurs informations associées.</returns>
        Task<IEnumerable<BonsaiAndChild>?> Get();


        /// <summary>
        /// Récupère tous les bonsaïs d'un utilisateur avec leurs informations associées.
        /// </summary>
        /// <param name="idUser">L'ID de l'utilisateur dont on veut récupérer les bonsaïs.</param>
        /// <returns>Une collection de bonsaïs avec leurs informations associées.</returns>
        Task<IEnumerable<BonsaiAndChild>> Get(int idUser);

        /// <summary>
        /// Récupère les informations détaillées d'un bonsaï spécifique par son ID.
        /// </summary>
        /// <param name="id">L'ID du bonsaï à récupérer.</param>
        /// <returns>Les informations détaillées du bonsaï.</returns>
        Task<BonsaiDisplayDTO?> GetByID(int id);


        /// <summary>
        /// Récupère tous les bonsaïs correspondant à un nom donné.
        /// </summary>
        /// <param name="name">Le nom à rechercher.</param>
        /// <returns>Une collection de bonsaïs correspondant au nom donné.</returns>
        Task<IEnumerable<BonsaiDisplayDTO>?> GetByName(string name);


        /// <summary>
        /// Met à jour les informations d'un bonsaï existant.
        /// </summary>
        /// <param name="bonsai">Le modèle de bonsaï avec les informations mises à jour.</param>
        /// <returns>True si la mise à jour est réussie, sinon false.</returns>
        Task<bool> Update(BonsaiDTO bonsai);


        /// <summary>
        /// Supprime un bonsaï par son ID.
        /// </summary>
        /// <param name="id">L'ID du bonsaï à supprimer.</param>
        /// <returns>True si la suppression est réussie, sinon false.</returns>
        Task<bool> Delete(int id);

    }
}
