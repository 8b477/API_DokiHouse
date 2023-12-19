namespace DAL_DokiHouse.Interfaces
{
    public interface IRepo<E, M, MC, MD, U, S>
        where E : class  // entité
        where M : class  // modele
        where MC : class // modele for create
        where MD : class // model for display
        where U : struct // int
        where S : class  // string
    {
        Task<IEnumerable<MD>> Get();
        Task<MD?> GetBy(U id); // retourne un élément par son identifiant en int par exemple 'id'
        Task<IEnumerable<MD>?> GetBy(S id); // retourne un élément par son identifiant en string par exemple 'nom'
        Task<bool> Create(MC modelToCreate);
        Task<bool> Update(U id, MC modelToUpdate);
        Task<bool> Delete(U id);
    }
}