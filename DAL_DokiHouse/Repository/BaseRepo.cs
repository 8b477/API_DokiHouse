using DAL_DokiHouse.Interfaces;
using Entities_DokiHouse.Interfaces;

using Dapper;
using System.Data;

namespace DAL_DokiHouse.Repository
{
    public abstract class BaseRepo<E, M, U, S> : IRepo<E, M, U, S>
        where E : class, IEntity<U>, new()
        where M : class
        where U : struct
        where S : class
    {

        #region Constructor

        protected readonly IDbConnection _connection;

        protected BaseRepo(IDbConnection connection) => (_connection) = (connection);

        #endregion


        // Récupère le nom de la table correspondante au modèle E : Entity.
        private string GetTableName()
        {
            return typeof(E).Name;
        }


        public virtual async Task<IEnumerable<M>> Get()
        {
            string query = $"SELECT * FROM [{GetTableName()}]";
            var result = await _connection.QueryAsync<M>(query);

            return result;
        }


        public virtual async Task<M?> GetBy(U id)
        {
            string tableName = GetTableName();
            string query = $"SELECT * FROM [{tableName}] WHERE Id = @Id";
            var result = await _connection.QuerySingleOrDefaultAsync<M>(query, new { Id = id });

            if (result is null)
                return null;

            return result;
        }


        public virtual async Task<IEnumerable<M>?> GetBy(S name) // --> Remplacer 'Name' par une variable
        {
            string tableName = GetTableName();
            string uppercaseName = name?.ToString()?.ToUpper() ?? "";
            string query = $"SELECT * FROM [{tableName}] WHERE UPPER([Name]) = @UppercaseName";
            var result = await _connection.QueryAsync<M>(query,new { UppercaseName = uppercaseName });

            if (result != null && result.Any())
            {
                return result;
            }
            return null;
        }


        public virtual async Task<bool> Delete(U id)
        {
            string tableName = GetTableName();
            string query = $"DELETE FROM [{tableName}] WHERE ID = @Id";
            int rowsAffected = await _connection.ExecuteAsync(query, new { Id = id });
            return rowsAffected > 0;
        }

    }
}