using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;


namespace Tools_DokiHouse.Services.Authentication
{
    public static class AuthenticationService
    {
        public static void AddAuthenticationAuth0(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = "https://dev-qq7s2j4r0zzrukm8.us.auth0.com/";
                options.Audience = "https://DokiHouse-Back";
            });
        }
    }
}
