
using BLL_DokiHouse.Models;

namespace BLL_DokiHouse.Interfaces
{

    public interface INoteBLLService
    {

        /// <summary>
        /// Crée une nouvelle note en utilisant les informations fournies dans l'objet de logique métier note.
        /// </summary>
        /// <param name="model">Objet de logique métier note à créer.</param>
        /// <returns>Une tâche asynchrone indiquant si la création a réussi (true) ou échoué (false).</returns>
        Task<bool> CreateNote(NoteBLL model);

        /// <summary>
        /// Met à jour une note existant en utilisant les informations fournies dans l'objet de logique métier note.
        /// </summary>
        /// <param name="model">Objet de logique métier note à mettre à jour.</param>
        /// <returns>Une tâche asynchrone indiquant si la mise à jour a réussi (true) ou échoué (false).</returns>
        Task<bool> UpdateNote(NoteBLL model);
    }

}
