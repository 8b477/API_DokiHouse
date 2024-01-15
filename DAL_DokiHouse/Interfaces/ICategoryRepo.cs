using DAL_DokiHouse.Interfaces.Generic;

using Entities_DokiHouse.Entities;

namespace DAL_DokiHouse.Interfaces
{
    public interface ICategoryRepo : IBaseRepo<Category, int , string>
    {

        /// <summary>
        /// Crée une nouvelle catégorie dans la base de données.
        /// </summary>
        /// <param name="model">Les informations de la catégorie à créer.</param>
        /// <returns>True si la création a réussi, sinon False.</returns>
        Task<bool> Create(Category model, int idBonsai);


        /// <summary>
        /// Met à jour les informations d'une catégorie dans la base de données.
        /// </summary>
        /// <param name="category">Les nouvelles informations de la catégorie.</param>
        /// <returns>True si la mise à jour a réussi, sinon False.</returns>
        Task<bool> Update(Category model);

        /// <summary>
        /// Check en DB si une catégorie est déjà présente pour le bonsai identifié
        /// </summary>
        /// <param name="idBonsai">Identifiant de type : 'int'</param>
        /// <returns></returns>
        Task<bool> IsAlreadyExists(int idBonsai);
    }
}
