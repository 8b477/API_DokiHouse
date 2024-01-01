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
        public int GetLoggedInUserId()
        {
            string? identifiant = _context?.HttpContext?.Items["identifiant"]?.ToString();

            if (int.TryParse(identifiant, out int id))
            {
                return id;
            }
            return 0;
        }


    }
}
