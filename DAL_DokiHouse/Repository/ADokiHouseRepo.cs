using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;
using Dapper;

using Entities_DokiHouse.Entities;

using System.Data.Common;

namespace DAL_DokiHouse.Repository
{
    public class ADokiHouseRepo : IADokiHouseRepo
    {

        #region Injection
        private readonly DbConnection _connection;
        public ADokiHouseRepo(DbConnection connection) => _connection = connection;
        #endregion

   
       

        public async Task<UserTest2?> GetUserInfosWithOwnPostsAndComments(int userId)
        {
            string sql = @"
        SELECT 
            u.Id AS UserId,
            u.Name,
            
            p.Id AS IdPost,
            p.Title AS PostTitle,
            p.Description AS PostDescription,
            p.Content AS PostContent,
            p.CreateAt AS PostCreateAt,
            p.ModifiedAt AS PostModifiedAt,
            p.IdUser AS IdUser,

            com.Id AS IdComment,
            com.Content AS CommentContent,
            com.CreatedAt AS CommentCreateAt,
            com.ModifiedAt AS CommentModifiedAt,
            com.IdPost

        FROM [dbo].[User] u
        LEFT JOIN [dbo].[Post] p ON p.IdUser = u.Id
        LEFT JOIN [dbo].[Comments] com ON com.IdPost = p.Id
        WHERE u.Id = @UserId";

            var userDictionary = new Dictionary<int, UserTest2>(); // -> User

            await _connection.QueryAsync<UserTest2, PostJoinDTO, CommentsJoinDTO, UserTest2>(
                sql,
                (user, post, comment) =>
                {
                    if (!userDictionary.TryGetValue(user.UserId, out var existingUser))
                    {
                        existingUser = user;
                        existingUser.Posts = new List<PostJoinDTO>();
                        userDictionary.Add(existingUser.UserId, existingUser);
                    }

                    if (post != null && !existingUser.Posts.Any(p => p.IdPost == post.IdPost))
                    {
                        post.Comments = new List<CommentsJoinDTO>();
                        existingUser.Posts.Add(post);
                    }

                    if (comment != null && existingUser.Posts.Any(p => p.IdPost == comment.IdPost))
                    {
                        existingUser.Posts.First(p => p.IdPost == comment.IdPost).Comments.Add(comment);
                    }

                    return existingUser;
                },
                new { UserId = userId },
                splitOn: "IdPost,IdComment");

            return userDictionary.Values.FirstOrDefault(); // Retourne le premier user, s'il y en a un.
        }

        public async Task<PostJoinDTO?> GetPostWithComments(int postId)
        {
            string sql = @"
        SELECT 
            p.Id AS IdPost,
            p.Title AS PostTitle,
            p.Description AS PostDescription,
            p.Content AS PostContent,
            p.CreateAt AS PostCreateAt,
            p.ModifiedAt AS PostModifiedAt,
            p.IdUser,

            com.Id AS IdComment,
            com.Content AS CommentContent,
            com.CreatedAt AS CommentCreateAt,
            com.ModifiedAt AS CommentModifiedAt,
            com.IdPost,
            com.IdUser

        FROM [dbo].[Post] p
        INNER JOIN [dbo].[Comments] com ON com.IdPost = p.Id
        WHERE p.Id = @PostId";

            var postDictionary = new Dictionary<int, PostJoinDTO>(); // -> Post

            await _connection.QueryAsync<PostJoinDTO, CommentsJoinDTO, PostJoinDTO>(
                sql,
                (post, comment) =>
                {
                    if (!postDictionary.TryGetValue(post.IdPost, out var existingPost))
                    {
                        existingPost = post;
                        existingPost.Comments = new List<CommentsJoinDTO>();
                        postDictionary.Add(existingPost.IdPost, existingPost);
                    }

                    if (comment != null && existingPost.IdPost == comment.IdPost)
                    {
                        existingPost.Comments.Add(comment);
                    }

                    return existingPost;
                },
                new { PostId = postId },
                splitOn: "IdPost,IdComment");

            return postDictionary.Values.FirstOrDefault(); // Retourne le premier post, s'il y en a un.
        }

    }


    public class UserTest2
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime UserCreateAt { get; set; }
        public DateTime UsermodifiedAt { get; set; }
        public List<PostJoinDTO>? Posts { get; set; }
    }


    public class UserTest
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public PictureProfil? PictureProfil { get; set; }
        public List<Post>? Posts { get; set; }
        public List<BonsaiDetailsDTO>? Bonsais { get; set; }
    }

    public class BonsaiTest
    {
        public int BonsaiId { get; set; }
        public int IdUser { get; set; }
        public string BonsaiName { get; set; } = string.Empty;
    }


    public class BonsaiDetailsDTO
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Name { get; set; } = string.Empty;
        public PictureBonsai? PictureBonsai { get; set; }
        public Category? Categories { get; set; }
        public Style? Styles { get; set; }
        public Note? Notes { get; set; }
    }

    public class BonsaiTest3
    {
        public int BonsaiId { get; set; }
        public int IdUser { get; set; }
        public string Name { get; set; } = string.Empty;
        public PictureBonsaiJoinDTO? PictureBonsai { get; set; }
        public CategoryJoinDTO? Categories { get; set; }
        public StyleJoinDTO? Styles { get; set; }
        public NoteJoinDTO? Notes { get; set; }
    }
} //->end namespace
