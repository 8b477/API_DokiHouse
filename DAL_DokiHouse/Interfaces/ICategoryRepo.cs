using DAL_DokiHouse.DTO;

namespace DAL_DokiHouse.Interfaces
{
    public interface ICategoryRepo
    {


        /// <summary>
        /// Crée une nouvelle catégorie dans la base de données.
        /// </summary>
        /// <param name="model">Les informations de la catégorie à créer.</param>
        /// <returns>True si la création a réussi, sinon False.</returns>
        Task<bool> Create(CategoryDTO model);


        /// <summary>
        /// Met à jour les informations d'une catégorie dans la base de données.
        /// </summary>
        /// <param name="category">Les nouvelles informations de la catégorie.</param>
        /// <returns>True si la mise à jour a réussi, sinon False.</returns>
        Task<bool> Update(CategoryDTO model);
    }
}
