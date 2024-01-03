using DAL_DokiHouse.DTO;

namespace DAL_DokiHouse.Interfaces
{
    public interface INoteRepo
    {
        Task<bool> Create(NoteDTO model);
        Task<bool> Update(NoteDTO model);
        Task<bool> NotValide(int idBonsai);
    }
}
