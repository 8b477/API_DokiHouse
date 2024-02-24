using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Services;
using DAL_DokiHouse;
using DAL_DokiHouse.Interfaces;
using DAL_DokiHouse.Repository;
using Tools_DokiHouse.Filters.JwtIdentifiantFilter;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;


namespace Tools_DokiHouse.Services.DependencyInjection
{
    public static class DependencyInjectionService
    {
        public static void ConfigureDependencyInjection(IServiceCollection services, IConfiguration configuration)
        {
            // Connection string
            string connectionString = configuration.GetConnectionString("dev") ?? "";

            //User Service
            services.AddScoped<IUserRepo, UserRepo>(provider => new UserRepo(new SqlConnection(connectionString)));

            services.AddScoped<IUserBLLService, UserBLLService>();


            //Picture Service
            services.AddScoped<IPictureBonsaiRepo, PictureBonsaiRepo>(provider => new PictureBonsaiRepo(new SqlConnection(connectionString)));

            services.AddScoped<IPictureBLLService, PictureBLLService>();


            //Bonsai Service
            services.AddScoped<IBonsaiRepo, BonsaiRepo>(provider => new BonsaiRepo(new SqlConnection(connectionString)));

            services.AddScoped<IBonsaiBLLService, BonsaiBLLService>();


            //Category Service
            services.AddScoped<ICategoryRepo, CategoryRepo>(provider => new CategoryRepo(new SqlConnection(connectionString)));

            services.AddScoped<ICategoryBLLService, CategoryBLLService>();


            //Style Service
            services.AddScoped<IStyleRepo, StyleRepo>(provider => new StyleRepo(new SqlConnection(connectionString)));

            services.AddScoped<IStyleBLLService, StyleBLLService>();


            //Note Service
            services.AddScoped<INoteRepo, NoteRepo>(provider => new NoteRepo(new SqlConnection(connectionString)));

            services.AddScoped<INoteBLLService, NoteBLLService>();


            //Post Service
            services.AddScoped<IPostRepo, PostRepo>(provider => new PostRepo(new SqlConnection(connectionString)));

            services.AddScoped<IPostBLLService, PostBLLService>();


            //Comments Service
            services.AddScoped<ICommentsRepo, CommentsRepo>(provider => new CommentsRepo(new SqlConnection(connectionString)));

            services.AddScoped<ICommentsBLLService, CommentsBLLService>();


            //UserBonsai Service
            services.AddScoped<IUserBonsaiRepo, UserBonsaiRepo>(provider => new UserBonsaiRepo(new SqlConnection(connectionString)));

            services.AddScoped<IUserBonsaiBLLService, UserBonsaiBLLService>();


            //PostComment Service
            services.AddScoped<IPostCommentRepo, PostCommentRepo>(provider => new PostCommentRepo(new SqlConnection(connectionString)));

            services.AddScoped<IPostCommentBLLService, PostCommentBLLService>();


            //Picture Service
            services.AddScoped<PictureBLLService>();


            //Token Service
            services.AddScoped<JwtUserIdentifiantFilter>();


        }
    }
}
