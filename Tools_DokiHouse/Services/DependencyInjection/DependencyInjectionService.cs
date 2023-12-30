using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Services;
using DAL_DokiHouse;
using DAL_DokiHouse.Interfaces;
using DAL_DokiHouse.Repository;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;

using Tools_DokiHouse.Filters.JwtIdentifiantFilter;

namespace Tools_DokiHouse.Services.DependencyInjection
{
    public static class DependencyInjectionService
    {
        public static void ConfigureDependencyInjection(IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("dev") ?? "";

            services.AddScoped<IUserRepo, UserRepo>(provider => new UserRepo(new SqlConnection(connectionString)));

            services.AddScoped<IUserBLLService, UserBLLService>();


            services.AddScoped<IPictureRepo, PictureRepo>(provider => new PictureRepo(new SqlConnection(connectionString)));

            services.AddScoped<IPictureBLLService, PictureBLLService>();


            services.AddScoped<IBonsaiRepo, BonsaiRepo>(provider => new BonsaiRepo(new SqlConnection(connectionString)));

            services.AddScoped<IBonsaiBLLService, BonsaiBLLService>();

            services.AddScoped<JwtUserIdentifiantFilter>();
        }
    }
}
