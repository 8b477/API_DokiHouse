using DAL_DokiHouse.DTO;

namespace DAL_DokiHouse.Interfaces
{
    public interface INoteRepo
    {

        /// <summary>
        /// Crée une nouvelle note à partir d'un objet DTO.
        /// </summary>
        /// <param name="model">Objet DTO de la note à créer.</param>
        /// <returns>Une tâche asynchrone qui indique si la création a réussi.</returns>
        Task<bool> Create(NoteDTO model);

        /// <summary>
        /// Met à jour une note existante à partir d'un objet DTO.
        /// </summary>
        /// <param name="model">Objet DTO de la note à mettre à jour.</param>
        /// <returns>Une tâche asynchrone qui indique si la mise à jour a réussi.</returns>
        Task<bool> Update(NoteDTO model);

        /// <summary>
        /// Supprime une note en base de donnée sur base d'un identifiant
        /// </summary>
        /// <param name="id">identifiant de type : 'int'</param>
        /// <returns>Retourne True si la suppression à réussie si non retourne False</returns>
        Task<bool> Delete(int id);

        /// <summary>
        /// Marque une note comme non valide en fonction de l'identifiant du bonsaï associé.
        /// </summary>
        /// <param name="idBonsai">Identifiant du bonsaï associé à la note.</param>
        /// <returns>Une tâche asynchrone qui indique si l'opération a réussi.</returns>
        Task<bool> NotValide(int idBonsai);
    }
}
