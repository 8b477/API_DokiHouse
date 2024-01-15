using DAL_DokiHouse.Interfaces.Generic;
using Dapper;

using Entities_DokiHouse.Interfaces;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_DokiHouse.Repository.Generic
{
    public abstract class BaseRepo<E, U, S> : IBaseRepo<E, U, S> where E : class, IEntity<U>, new()
            where U : struct
            where S : class
    {

        #region Constructor

        protected readonly IDbConnection _connection;

        protected BaseRepo(IDbConnection connection) => _connection = connection;

        #endregion

        #region private methods
        private string GetTableName()
        {
            return typeof(E).Name;
        }

        private string FirstCharSubstring(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            string inputToLower = input.ToLower();

            return $"{inputToLower[0].ToString().ToUpper()}{input.Substring(1)}";
        }

        #endregion


        public virtual async Task<IEnumerable<E>> Get()
        {
            string query = $"SELECT * FROM [{GetTableName()}]";
            var result = await _connection.QueryAsync<E>(query);

            return result;
        }


        public virtual async Task<E?> GetBy(U id)
        {
            string tableName = GetTableName();
            string query = $"SELECT * FROM [{tableName}] WHERE Id = @Id";
            var result = await _connection.QuerySingleOrDefaultAsync<E>(query, new { Id = id });

            if (result is null)
                return null;

            return result;
        }


        public virtual async Task<IEnumerable<E>?> GetBy(S name, S stringIdentifiant)
        {
            string tableName = GetTableName();
            string uppercaseName = name?.ToString()?.ToUpper() ?? "";
            string reFormatStringIdentifiant = FirstCharSubstring(stringIdentifiant.ToString() ?? "Name");
            string query = $"SELECT * FROM [{tableName}] WHERE UPPER([{reFormatStringIdentifiant}]) = @UppercaseName";
            var result = await _connection.QueryAsync<E>(query, new { UppercaseName = uppercaseName });

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
