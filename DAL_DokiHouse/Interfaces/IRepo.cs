using Entities_DokiHouse.Interfaces;

namespace DAL_DokiHouse.Interfaces
{
    public interface IRepo<E, M, U, S>
        where E : class, IEntity<U>, new() // entité
        where M : class
        where U : struct // int
        where S : class  // string
    {
        Task<IEnumerable<M>> Get();
        Task<M?> GetBy(U id); // retourne un élément par son identifiant en int par exemple 'id'
        Task<IEnumerable<M>?> GetBy(S id); // retourne un élément par son identifiant en string par exemple 'nom'
        Task<bool> Delete(U id);
    }
}