namespace API_DokiHouse.Tools
{
    public class GetInfosHTTPContext
    {

        #region Injection
        private readonly IHttpContextAccessor _context;

        public GetInfosHTTPContext(IHttpContextAccessor context) => _context = context; 
        #endregion


        /// <summary>
        /// Méthode qui permet de récupérer dans le HttpContext l'item nommé 'idenfifiant'
        /// et le Parse en entier
        /// </summary>
        /// <returns>Retourne un id de type : 'int', retourne 0 si la méthode à échoué</returns>
        public int GetIdUserTokenInHttpContext()
        {
            string? identifiant = _context?.HttpContext?.Items["id"]?.ToString();

            if (int.TryParse(identifiant, out int id))
            {
                return id;
            }
            return 0;
        }


        /// <summary>
        /// Méthode qui permet de récupérer dans le HttpContext l'item nommé 'name'
        /// </summary>
        /// <returns>Retourne la valeur de name sous le format 'string', si aucune valeur trouver retourne string.empty</returns>
        public string GetNameUserTokenInHttpContext()
        {
            string? name = _context?.HttpContext?.Items["name"]?.ToString();

            return name ?? string.Empty;
        }



        /// <summary>
        /// Méthode qui permet de récupérer dans le HttpContext l'item nommé 'role'
        /// </summary>
        /// <returns>Retourne la valeur de role sous le format 'string', si aucune valeur trouver retourne string.empty</returns>
        public string GetRoleUserTokenInHttpContext()
        {
            string? role = _context?.HttpContext?.Items["role"]?.ToString();

            return role ?? string.Empty;
        }


    }
}
