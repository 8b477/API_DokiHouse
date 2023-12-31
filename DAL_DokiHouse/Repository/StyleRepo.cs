using DAL_DokiHouse.Interfaces;

using System.Data.Common;

namespace DAL_DokiHouse.Repository
{
    public class StyleRepo : IStyleRepo
    {

        #region Injection

        private readonly DbConnection _connection;

        public StyleRepo(DbConnection connection) => _connection = connection;

        #endregion

    }
}
