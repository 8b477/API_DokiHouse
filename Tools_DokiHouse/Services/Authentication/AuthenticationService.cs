using Tools_DokiHouse.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Tools_DokiHouse.Services.Authentication
{
    public static class AuthenticationService
    {

        /// <summary>
        /// Ajoute une configuration sur le quelle se basé pour savoir si un token est correct ou pas
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureAuthentication(IServiceCollection services)
        {
            services.AddSingleton<JWTService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var jwtService = services.BuildServiceProvider().GetService<JWTService>();

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(jwtService!.secretKey)),
                    };
                });
        }


        /// <summary>
        /// Authentification via le services de Auth0
        /// </summary>
        /// <param name="services"></param>
        //public static void AddAuthenticationAuth0(IServiceCollection services)
        //{
        //    services.AddAuthentication(options =>
        //    {
        //        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //    }).AddJwtBearer(options =>
        //    {
        //        options.Authority = "https://dev-qq7s2j4r0zzrukm8.us.auth0.com/";
        //        options.Audience = "https://DokiHouse-Back";
        //    });
        //}
    }
}
