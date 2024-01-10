using BLL_DokiHouse.ExceptionHandler;
using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Models;
using BLL_DokiHouse.Tools;
using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;

namespace BLL_DokiHouse.Services
{
    public class NoteBLLService : INoteBLLService
    {

        #region Injection

        private readonly INoteRepo _noteRepo;

        public NoteBLLService (INoteRepo noteRepo) => _noteRepo = noteRepo;
        #endregion


        public async Task<bool> CreateNote(NoteBLL model)
        {
            if (await _noteRepo.NotValide(model.IdBonsai))
                throw new BusinessException("Le Bonsai possède déjà une Note, update le !");

            NoteDTO note = Mapper.NoteBLLToDAL(model);

            return await _noteRepo.Create(note);
        }

        public Task<bool> DeleteNote(int id)
        {
            return _noteRepo.Delete(id);
        }

        public async Task<bool> UpdateNote(NoteBLL model)
        {
            NoteDTO note = Mapper.NoteBLLToDAL(model);

            return await _noteRepo.Update(note);
        }

    }
}
