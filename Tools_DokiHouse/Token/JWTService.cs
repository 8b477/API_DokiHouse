using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Tools_DokiHouse.Token
{
    public class JWTService
    {

        public readonly string secretKey;

        /// <summary>
        /// Génère une clé secrete pour la validation du token
        /// </summary>
        public JWTService()
        {
            // Charger la clé depuis les variables d'environnement
            secretKey = Environment.GetEnvironmentVariable("SECRET_KEY");

            if (string.IsNullOrEmpty(secretKey))
            {
                // Si la clé n'est pas définie, générer une nouvelle clé
                secretKey = GenerateRandomKey();
                // Stocker la nouvelle clé dans les variables d'environnement
                Environment.SetEnvironmentVariable("SECRET_KEY", secretKey);
            }
        }


        // Si SECRET_KEY est null alors je construit la clé ici
        private string GenerateRandomKey(int length = 32)
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var bytes = new byte[length];
            rngCryptoServiceProvider.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }



        /// <summary>
        /// Génère un token avec un id et un role
        /// </summary>
        /// <param name="userId">l'identifiant</param>
        /// <param name="role">la valeur du rôle</param>
        /// <returns>Retourne un token avec un rôle et un identifiant</returns>
        public string GenerateToken(string userId, string name, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Convert.FromBase64String(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                        new Claim(ClaimTypes.NameIdentifier, userId),
                        new Claim(ClaimTypes.Name, name),
                        new Claim(ClaimTypes.Role, role )
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}