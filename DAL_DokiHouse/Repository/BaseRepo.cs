using DAL_DokiHouse.Interfaces;

using Dapper;

using Entities_DokiHouse.Interfaces;

using System.Data;


namespace DAL_DokiHouse.Repository
{
    public abstract class BaseRepo<E, M, MC, MD, U, S> : IRepo<E, M, MC, MD, U, S>
        where E : class, IEntity<U>, new()
        where M : class
        where MC : class
        where MD : class
        where U : struct
        where S : class
    {
        #region Constructor
        protected readonly IDbConnection _connection;

        protected BaseRepo(IDbConnection connection) => (_connection) = (connection);     
        #endregion

        public virtual async Task<IEnumerable<MD>> Get()
        {
            string query = $"SELECT * FROM [{GetTableName()}]";
            var result = await _connection.QueryAsync<MD>(query);

            return result;
        }

        public virtual async Task<MD?> GetBy(U id)
        {
            string tableName = GetTableName();
            string query = $"SELECT * FROM [{tableName}] WHERE Id = @Id";
            var result = await _connection.QuerySingleOrDefaultAsync<MD>(query, new { Id = id });

            if (result is null)
                return null;

            return result;
        }

        public virtual async Task<IEnumerable<MD>?> GetBy(S name)
        {
            string tableName = GetTableName();
            string uppercaseName = name?.ToString()?.ToUpper() ?? "";
            string query = $"SELECT * FROM [{tableName}] WHERE UPPER([Name]) = @UppercaseName";
            var result = await _connection.QueryAsync<MD>(query,new { UppercaseName = uppercaseName });

            if (result != null && result.Any())
            {
                return result;
            }
            return null;
        }

        public virtual async Task<bool> Create(MC modelToCreate)
        {
            string tableName = GetTableName();
            var propertyDict = GetPropertyDictionary(modelToCreate);
            string columns = string.Join(", ", propertyDict.Keys);
            string values = string.Join(", ", propertyDict.Keys.Select(k => "@" + k));
            string query = $"INSERT INTO [{tableName}] ({columns}) VALUES ({values})";
            int rowAffected = await _connection.ExecuteAsync(query, modelToCreate);

            return rowAffected > 0;
        }

        public virtual async Task<bool> Update(U id, MC item)
        {
            string tableName = GetTableName();    
            var parameters = new DynamicParameters(item); // Dictionnaire de params pour les colonnes à mettre à jour
            parameters.Add("ID", id); // Ajouter le paramètre ID pour la clause WHERE
            string setClause = GetSetClause(item);
            string query = $"UPDATE [{tableName}] SET {setClause} WHERE Id = @ID";
            int rowsAffected = await _connection.ExecuteAsync(query, parameters);

            return rowsAffected > 0;
        }

        public virtual async Task<bool> Delete(U id)
        {
            string tableName = GetTableName();
            string query = $"DELETE FROM [{tableName}] WHERE ID = @Id";
            int rowsAffected = await _connection.ExecuteAsync(query, new { Id = id });
            return rowsAffected > 0;
        }

        #region Private Methods

        // Récupère le nom de la table correspondante au modèle E : Entity.
        private string GetTableName()
        {
            return typeof(E).Name;
        }

        private string GetSetClause(MC item)
        {
// Récupérer les noms des propriétés de l'item pour les bind en tant que params sur le nom des colonnes de ma table côté DB
            var columnNames = typeof(MC)
                .GetProperties()
                .Select(p => $"{p.Name} = @{p.Name}");

            return string.Join(", ", columnNames);
        }

        // Méthode pour obtenir un dictionnaire de propriétés et valeurs de l'objet modèle
        private Dictionary<string, object?> GetPropertyDictionary(MC item)
        {
            return typeof(MC)
                .GetProperties()
                .ToDictionary(property => property.Name, property => property.GetValue(item));
        }
        #endregion
    }
}