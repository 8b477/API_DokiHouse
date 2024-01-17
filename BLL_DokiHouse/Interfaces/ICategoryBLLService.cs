
using API_DokiHouse.Models;

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
        Task<bool> CreateCategory(int idBonsai, CategoryModel model);


        /// <summary>
        /// Met à jour une catégorie existante.
        /// </summary>
        /// <param name="model">Le modèle de catégorie à mettre à jour.</param>
        /// <returns>True si la mise à jour est réussie, sinon false.</returns>
        Task<bool> UpdateCategory(CategoryModel model, int idCategory);


        /// <summary>
        /// Supprime une catégorie présente en base de données sur base d'un identifiant id.
        /// </summary>
        /// <param name="idCategory">identifiant de type INT</param>
        /// <returns>Retourne TRUE si la suppresion à réssie si non retourne FALSE.</returns>
        Task<bool> DeleteCategory(int idCategory);
    }
}
