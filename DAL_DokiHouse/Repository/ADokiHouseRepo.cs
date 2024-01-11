using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;
using Dapper;

using Entities_DokiHouse.Entities;

using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;

namespace DAL_DokiHouse.Repository
{
    public class ADokiHouseRepo : IADokiHouseRepo
    {

        #region Injection
        private readonly DbConnection _connection;
        public ADokiHouseRepo(DbConnection connection) => _connection = connection;
        #endregion



        //public async Task<IEnumerable<FullJoinDTO>?> InfosPaginated(int startIndex, int pageSize, CancellationToken cancellationToken)
        //{
        //    string sql = @"
        //SELECT 
        //    u.Id AS UserId, u.Name AS UserName, u.Role, u.IdPictureProfil,
        //    b.Id AS BonsaiId, b.Name AS BonsaiName, b.Description AS BonsaiDescription, b.IdUser AS BonsaiUserId,
        //    c.Id AS CategoryId, c.Shohin, c.Mame, c.Chokkan, c.Moyogi, c.Shakan, c.Kengai, c.HanKengai, c.Ikadabuki, c.Neagari, c.Literati, c.YoseUe, c.Ishitsuki, c.Kabudachi, c.Kokufu, c.Yamadori, c.Perso AS CategoryPerso, c.IdBonsai,
        //    s.Id AS StyleID, Bunjin, s.Bankan, s.Korabuki, s.Ishituki, s.Perso AS StylePerso, s.IdBonsai,
        //    n.Id AS NoteId, n.Title, n.Description AS NoteDescription, n.CreateAt, n.IdBonsai
        //FROM [dbo].[User] u
        //LEFT JOIN [dbo].[Bonsai] b ON u.Id = b.IdUser
        //LEFT JOIN [dbo].[Category] c ON b.Id = c.IdBonsai
        //LEFT JOIN [dbo].[Style] s ON b.Id = s.IdBonsai
        //LEFT JOIN [dbo].[Note] n ON b.Id = n.IdBonsai
        //ORDER BY u.Id
        //OFFSET @StartIndex ROWS FETCH NEXT @PageSize ROWS ONLY";

        //    //Ici je map
        //    var fullInfosUser = await _connection.QueryAsync<UserJoinDTO, BonsaiJoinDTO, CategoryJoinDTO, StyleJoinDTO, NoteJoinDTO, FullJoinDTO>(
        //        sql,
        //        (user, bonsai, category, style, note) =>
        //        {
        //            FullJoinDTO every = new()
        //            {
        //                User = new UserJoinDTO // Ici User ne peut pas être null
        //                {
        //                    UserId = user.UserId,
        //                    UserName = user.UserName,
        //                    Role = user.Role,
        //                    IdPictureProfil = user.IdPictureProfil
        //                },
        //                Bonsai = bonsai != null ? new BonsaiJoinDTO
        //                {
        //                    BonsaiId = bonsai.BonsaiId,
        //                    BonsaiName = bonsai.BonsaiName,
        //                    BonsaiDescription = bonsai.BonsaiDescription,
        //                    BonsaiUserId = bonsai.BonsaiUserId
        //                } : null,
        //                Category = category != null ? new CategoryJoinDTO
        //                {
        //                    CategoryId = category.CategoryId,
        //                    Shohin = category.Shohin,
        //                    Mame = category.Mame,
        //                    Chokkan = category.Chokkan,
        //                    Moyogi = category.Moyogi,
        //                    Shakan = category.Shakan,
        //                    Kengai = category.Kengai,
        //                    HanKengai = category.HanKengai,
        //                    Ikadabuki = category.Ikadabuki,
        //                    Neagari = category.Neagari,
        //                    Literati = category.Literati,
        //                    YoseUe = category.YoseUe,
        //                    Ishitsuki = category.Ishitsuki,
        //                    Kabudachi = category.Kabudachi,
        //                    Kokufu = category.Kokufu,
        //                    Yamadori = category.Yamadori,
        //                    CategoryPerso = category.CategoryPerso
        //                } : null,
        //                Style = style != null ? new StyleJoinDTO
        //                {
        //                    StyleId = style.StyleId,
        //                    Bunjin = style.Bunjin,
        //                    Bankan = style.Bankan,
        //                    Korabuki = style.Korabuki,
        //                    Ishituki = style.Ishituki,
        //                    StylePerso = style.StylePerso
        //                } : null,
        //                Note = note != null ? new NoteJoinDTO
        //                {
        //                    NoteId = note.NoteId,
        //                    Title = note.Title,
        //                    NoteDescription = note.NoteDescription
        //                } : null
        //            };
        //            return every;
        //        },
        //        new { StartIndex = startIndex, PageSize = pageSize },
        //        splitOn: "bonsaiId,categoryId,styleId,noteId"
        //    )
        //    ;
        //    return fullInfosUser;
        //}

        public async Task<UserTest?> GetInfosUserWithOwnBonsaisAndDetails(int startIndex, int pageSize, int userId)
        {
            string sql = @"
            SELECT 
                u.Id AS UserId,
                u.Name,
                b.Id AS BonsaiId,
                b.Name,
                b.IdUser,

                c.Id AS CategoryId,
                c.Shohin,
                c.Mame,
                c.Chokkan,
                c.Moyogi,
                c.Shakan,
                c.Kengai,
                c.HanKengai,
                c.Ikadabuki,
                c.Neagari,
                c.Literati,
                c.YoseUe,
                c.Ishitsuki,
                c.Kabudachi,
                c.Kokufu,
                c.Yamadori,
                c.Perso AS CategoryPerso,
                c.IdBonsai,

                s.Id AS StyleID,
                Bunjin,
                s.Bankan,
                s.Korabuki,
                s.Ishituki,
                s.Perso AS StylePerso,
                s.IdBonsai,

                n.Id AS NoteId,
                n.Title,
                n.Description AS NoteDescription,
                n.CreateAt,
                n.IdBonsai

            FROM [dbo].[User] u
            JOIN [dbo].[Bonsai] b ON b.IdUser = u.Id
            LEFT JOIN [dbo].[Category] c ON c.IdBonsai = b.Id
            LEFT JOIN [dbo].[Style] s ON s.IdBonsai = b.Id
            LEFT JOIN [dbo].[Note] n ON n.IdBonsai = b.Id
            OFFSET @StartIndex ROWS FETCH NEXT @PageSize ROWS ONLY
            WHERE u.Id = @UserId";

            var userDictionary = new Dictionary<int, UserTest>(); // -> User

            await _connection.QueryAsync<UserTest, BonsaiTest3, CategoryJoinDTO, StyleJoinDTO, NoteJoinDTO, UserTest>(
                sql,
                (user, bonsai, category, style, note) =>
                {
                    if (!userDictionary.TryGetValue(user.UserId, out var existingUser))
                    {
                        existingUser = user;
                        existingUser.Bonsais = new List<BonsaiTest3>();
                        userDictionary.Add(existingUser.UserId, existingUser);
                    }

                    bonsai.Categories = category;
                    bonsai.Styles = style;
                    bonsai.Notes = note;

                    existingUser.Bonsais.Add(bonsai);

                    return existingUser;
                },
                new { UserId = userId, StartIndex = startIndex, PageSize = pageSize },
                splitOn: "BonsaiId,CategoryId,StyleID,NoteId");

            return userDictionary.Values.FirstOrDefault();
        }


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
        public string Name { get; set; } = string.Empty;
        public DateTime UserCreateAt { get; set; }
        public DateTime UsermodifiedAt { get; set; }
        public List<PostJoinDTO>? Posts { get; set; }
    }


    public class UserTest
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<BonsaiTest3>? Bonsais { get; set; }
        public List<PostJoinDTO>? Posts { get; set; }
    }

    public class BonsaiTest
    {
        public int BonsaiId { get; set; }
        public int IdUser { get; set; }
        public string UserName { get; set; } = string.Empty;
    }


    public class BonsaiTest2
    {
        public int BonsaiId { get; set; }
        public int IdUser { get; set; }
        public string UserName { get; set; } = string.Empty;
        public CategoryJoinDTO? Categories { get; set; }
        public StyleJoinDTO? Styles { get; set; }
        public NoteJoinDTO? Notes { get; set; }
    }

    public class BonsaiTest3
    {
        public int BonsaiId { get; set; }
        public int IdUser { get; set; }
        public string UserName { get; set; } = string.Empty;
        public CategoryJoinDTO? Categories { get; set; }
        public StyleJoinDTO? Styles { get; set; }
        public NoteJoinDTO? Notes { get; set; }
    }
} //->end namespace
