using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Services;
using DAL_DokiHouse;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;


namespace Tools_DokiHouse.Services
{
    public static class DependencyInjectionService
    {
        public static void ConfigureDependencyInjection(IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("dev") ?? "";

            services.AddScoped<IUserRepo, UserRepo>(provider => new UserRepo(new SqlConnection(connectionString)));

            services.AddScoped<IUserBLLService, UserBLLService>();
                

        }
    }
}
