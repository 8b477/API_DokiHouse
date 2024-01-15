using API_DokiHouse.Models;
using BLL_DokiHouse.ExceptionHandler;
using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Tools;
using DAL_DokiHouse.Interfaces;

using Entities_DokiHouse.Entities;

namespace BLL_DokiHouse.Services
{
    public class NoteBLLService : INoteBLLService
    {

        #region Injection

        private readonly INoteRepo _noteRepo;

        public NoteBLLService (INoteRepo noteRepo) => _noteRepo = noteRepo;
        #endregion


        public async Task<bool> CreateNote(int idNote, NoteModel model)
        {
            if (await _noteRepo.IsAlreadyExists(idNote))
                throw new BusinessException("Le Bonsai possède déjà une Note, update le !");

            Note note = Mapping.NoteCreateBLLtoDAL(model);

            return await _noteRepo.Create(idNote, note);
        }

        public Task<bool> DeleteNote(int id)
        {
            return _noteRepo.Delete(id);
        }

        public async Task<bool> UpdateNote(int idNote, NoteModel model)
        {
            Note note = Mapping.NoteUpdateBLLtoDAL(model);

            return await _noteRepo.Update(idNote, note);
        }

    }
}
