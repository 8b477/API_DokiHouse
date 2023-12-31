using DAL_DokiHouse.Interfaces;

using System.Data.Common;

namespace DAL_DokiHouse.Repository
{
    public class NoteRepo : INoteRepo
    {

        #region Injection

        private readonly DbConnection _connection;

        public NoteRepo(DbConnection connection) => _connection = connection;
        
        #endregion

    }
}
