using DAL_DokiHouse.Interfaces;
using Dapper;

using System.Data;


namespace DAL_DokiHouse.Repository
{
    public abstract class BaseRepo<E, M, MC, MD, U, S> : IRepo<E, M, MC, MD, U, S>
        where E : class  // entité
        where M : class  // modele
        where MC : class // modele for create
        where MD : class // model for display
        where U : struct // int
        where S : class  // string
    {

        #region Constructor

        protected readonly IDbConnection _connection;

        public BaseRepo(IDbConnection connection)
        {
            _connection = connection;
        }

        #endregion


        public async Task<IEnumerable<MD>> Get()
        {
            string query = $"SELECT * FROM [{GetTableName()}]";
            var result = await _connection.QueryAsync<MD>(query);

            return result;
        }

        public async Task<MD?> GetBy(U id)
        {
            string tableName = GetTableName();
            string query = $"SELECT * FROM [{tableName}] WHERE Id = @Id";

            var result = await _connection.QuerySingleOrDefaultAsync<MD>(query, new { Id = id });

            if (result is null)
                return null;

            return result;
        }

        public async Task<IEnumerable<MD>?> GetBy(S name)
        {
            string tableName = GetTableName();

            string query = $"SELECT * FROM [{tableName}] WHERE [Name] = @Name";

            var result = await _connection.QueryAsync<MD>(query, new { Name = name });

            if (result != null && result.Any())
            {
                return result;
            }

            return null;
        }

        public async Task<bool> Create(MC modelToCreate)
        {
            string tableName = GetTableName();
            var propertyDict = GetPropertyDictionary(modelToCreate);

            string columns = string.Join(", ", propertyDict.Keys);
            string values = string.Join(", ", propertyDict.Keys.Select(k => "@" + k));
            string query = $"INSERT INTO [{tableName}] ({columns}) VALUES ({values})";
            int rowAffected = await _connection.ExecuteAsync(query, modelToCreate);

            return rowAffected > 0;
        }

        public async Task<MC?> Update(U id, MC item)
        {
            string tableName = GetTableName();

            // Créer un dictionnaire de paramètres pour les colonnes à mettre à jour
            var parameters = new DynamicParameters(item);

            // Vérifier si l'ID est de type int
            if (id is int)
            {
                // Ajouter l'ID comme paramètre
                parameters.Add("ID", id);

                // Construire la requête SQL
                string query = $"UPDATE [{tableName}] SET {GetUpdateColumns(parameters)} WHERE Id = @ID";

                // Exécuter la requête et obtenir le nombre de lignes affectées
                int rowsAffected = await _connection.ExecuteAsync(query, parameters);

                // Retourner l'objet mis à jour si au moins une ligne a été affectée
                return rowsAffected > 0 ? item : null;
            }
            return null;
        }

        public async Task<bool> Delete(U id)
        {
            string tableName = GetTableName();
            string query = $"DELETE FROM [{tableName}] WHERE ID = @Id";
            int rowsAffected = await _connection.ExecuteAsync(query, new { Id = id });
            return rowsAffected > 0;
        }

        #region Private Methods

        /// <summary>
        /// Récupère le nom de la table correspondante au modèle T.
        /// </summary>
        /// <returns>Le nom de la table.</returns>
        private string GetTableName()
        {
            return typeof(E).Name;
        }


        // Méthode pour obtenir un dictionnaire de propriétés et valeurs de l'objet modèle
        private Dictionary<string, object?> GetPropertyDictionary(MC item)
        {
            return typeof(MC)
                .GetProperties()
                .ToDictionary(property => property.Name, property => property.GetValue(item));
        }


        /// <summary>
        /// La méthode GetUpdateColumns génère dynamiquement la liste des colonnes à mettre à jour dans la requête SQL.
        /// Cette méthode est utilisée dans le cadre de la mise à jour d'une ligne dans la base de données.
        /// </summary>
        /// <param name="parameters">Dictionnaire de paramètres contenant les valeurs des colonnes à mettre à jour.</param>
        /// <returns>Une chaîne représentant la partie SET de la requête SQL, spécifiant les colonnes à mettre à jour avec leurs nouvelles valeurs.</returns>
        private string GetUpdateColumns(DynamicParameters parameters)
        {
            // La classe DynamicParameters de Dapper :
            // - permet de créer automatiquement les paramètres à partir de notre modèle (item).

            // Récupérer les noms de colonnes à partir des paramètres
            var columnNames = parameters.ParameterNames
                .Where(p => p != "Id") // Exclure la colonne ID
                .Select(p => $"{p} = @{p}");

            // Joindre les noms de colonnes avec une virgule
            return string.Join(", ", columnNames);
        }
        #endregion

    }
}
