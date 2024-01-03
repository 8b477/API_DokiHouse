using BLL_DokiHouse.Models;

using DAL_DokiHouse.DTO;


namespace BLL_DokiHouse.Interfaces
{
    public interface ICategoryBLLService
    {

        /// <summary>
        /// Crée une nouvelle catégorie associée à un bonsaï spécifique.
        /// </summary>
        /// <param name="idBonsai">L'ID du bonsaï auquel la catégorie sera associée.</param>
        /// <param name="model">Le modèle de catégorie à créer.</param>
        /// <returns>True si la création est réussie, sinon false.</returns>
        Task<bool> Create(int idBonsai, CategoryBLL model);


        /// <summary>
        /// Met à jour une catégorie existante.
        /// </summary>
        /// <param name="model">Le modèle de catégorie à mettre à jour.</param>
        /// <returns>True si la mise à jour est réussie, sinon false.</returns>
        Task<bool> Update(CategoryBLL model);
    }
}
