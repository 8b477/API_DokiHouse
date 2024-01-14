

using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;

using Dapper;

using Entities_DokiHouse.Entities;

using System.Data;

namespace DAL_DokiHouse.Repository
{
    public class PostRepo : BaseRepo<Post, PostDTO, int, string>, IPostRepo
    {
        #region Injection
        public PostRepo(IDbConnection connection) : base(connection){}

        #endregion


        public async Task<bool> Create(PostDTO post)
        {
            string sql = @"
        INSERT INTO [Post]
        (Title, Description, Content, IdUser, CreateAt, ModifiedAt)
        VALUES (@Title, @Description, @Content, @IdUser, @CreateAt, @ModifiedAt)";

            DynamicParameters parameters = new();
            parameters.Add("@Title", post.Title);
            parameters.Add("@Description", post.Description);
            parameters.Add("@Content", post.Content);
            parameters.Add("@IdUser", post.IdUser);
            parameters.Add("@CreateAt", post.CreateAt);
            parameters.Add("@ModifiedAt", post.ModifiedAt);

            int rowAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowAffected > 0;
        }

        public async Task<IEnumerable<PostDTO>?> GetOwnPosts(int idUser)
        {
            string sql = @"SELECT * FROM [Post] WHERE IdUser = @idUserParam";

            IEnumerable<PostDTO>? postCollection = await _connection.QueryAsync<PostDTO>(sql, new { idUserParam = idUser});

            return postCollection;
        }

        public async Task<bool> Update(PostDTO post)
        {
            string sql = @"
        UPDATE [Post]
        SET Description = @Description, @Content = Content 
        WHERE IdUser = @id";

            DynamicParameters parameters = new();
            parameters.Add("@Description", post.Description);
            parameters.Add("@Content", post.Content);

            int rowAffected = await _connection.ExecuteAsync(sql, parameters);

            return rowAffected < 0;
        }

        public async Task<PostDTO>? GetUserPostsCommentsById(int postId)
        {
            string sql = @"
        SELECT          
            p.Id,
            p.Title,
            p.Description,
            p.Content,
            p.CreateAt,
            p.ModifiedAt,
            p.IdUser,

            com.Id,
com.IdUser,
com.IdPost
            com.Content,
            com.CreatedAt,
            com.ModifiedAt,

        FROM [dbo].[Post] p
        JOIN [dbo].[Comments] com ON com.IdPost = p.Id
        WHERE p.Id = @postId";

            var postDictionary = new Dictionary<int, PostDTO>();

            await _connection.QueryAsync<PostDTO, Comments, PostDTO>(
                sql,
                (post, comment) =>
                {
                    if (!postDictionary.TryGetValue(post.Id, out var existingPost))
                    {
                        existingPost = post;
                        existingPost.Comments = new List<Comments>();
                        postDictionary.Add(existingPost.Id, existingPost);
                    }
                    return existingPost;
                },
                new { UserId = postId },
                splitOn: "Id,Id");

            return postDictionary.Values.FirstOrDefault();// ?? new UserDetailsPostDTO();
        }
    }
}
