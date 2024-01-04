using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;

using Dapper;
using System.Data.Common;

namespace DAL_DokiHouse.Repository
{
    public class ADokiHouseRepo : IADokiHouseRepo
    {
        
        #region Injection
        private readonly DbConnection _connection;
        public ADokiHouseRepo(DbConnection connection) => _connection = connection;
        #endregion


        public async Task<IEnumerable<EveryDTO>?> Infos(CancellationToken cancellationToken)
        {
            string sql = @"
        SELECT 
            u.Id AS UserId, u.Name AS UserName, u.Role, u.IdPictureProfil, 
            b.Id AS BonsaiId, b.Name AS BonsaiName, b.Description AS BonsaiDescription, b.IdUser AS BonsaiUserId,
            c.Id AS CategoryId, c.Shohin, c.Mame, c.Chokkan, c.Moyogi, c.Shakan, c.Kengai, c.HanKengai, c.Ikadabuki, c.Neagari, c.Literati, c.YoseUe, c.Ishitsuki, c.Kabudachi, c.Kokufu, c.Yamadori, c.Perso AS CategoryPerso, c.IdBonsai,
            s.Id AS StyleID, Bunjin, s.Bankan, s.Korabuki, s.Ishituki, s.Perso AS StylePerso, s.IdBonsai,
            n.Id AS NoteId, n.Title, n.Description AS NoteDescription, n.CreateAt, n.IdBonsai
        FROM [dbo].[User] u
        LEFT JOIN [dbo].[Bonsai] b ON u.Id = b.IdUser
        LEFT JOIN [dbo].[Category] c ON b.Id = c.IdBonsai
        LEFT JOIN [dbo].[Style] s ON b.Id = s.IdBonsai
        LEFT JOIN [dbo].[Note] n ON b.Id = n.IdBonsai";

            //Ici je map
            var fullInfosUser = await _connection.QueryAsync<UserJoinDTO, BonsaiJoinDTO, CategoryJoinDTO, StyleJoinDTO, NoteJoinDTO, EveryDTO>(
                sql,
                (user, bonsai, category, style, note) =>
                {
                    EveryDTO every = new()
                    {
                        User = new UserJoinDTO // Ici User ne peut pas être null
                        {
                            UserId = user.UserId,
                            UserName = user.UserName,
                            Role = user.Role,
                            IdPictureProfil = user.IdPictureProfil
                        },
                        Bonsai = bonsai != null ? new BonsaiJoinDTO
                        {
                            BonsaiId = bonsai.BonsaiId,
                            BonsaiName = bonsai.BonsaiName,
                            BonsaiDescription = bonsai.BonsaiDescription,
                            BonsaiUserId = bonsai.BonsaiUserId
                        } : null,
                        Category = category != null ? new CategoryJoinDTO
                        {
                            CategoryId = category.CategoryId,
                            Shohin = category.Shohin,
                            Mame = category.Mame,
                            Chokkan = category.Chokkan,
                            Moyogi = category.Moyogi,
                            Shakan = category.Shakan,
                            Kengai = category.Kengai,
                            HanKengai = category.HanKengai,
                            Ikadabuki = category.Ikadabuki,
                            Neagari = category.Neagari,
                            Literati = category.Literati,
                            YoseUe = category.YoseUe,
                            Ishitsuki = category.Ishitsuki,
                            Kabudachi = category.Kabudachi,
                            Kokufu = category.Kokufu,
                            Yamadori = category.Yamadori,
                            CategoryPerso = category.CategoryPerso
                        } : null,
                        Style = style != null ? new StyleJoinDTO
                        {
                            StyleId = style.StyleId,
                            Bunjin = style.Bunjin,
                            Bankan = style.Bankan,
                            Korabuki = style.Korabuki,
                            Ishituki = style.Ishituki,
                            StylePerso = style.StylePerso
                        } : null,
                        Note = note != null ? new NoteJoinDTO
                        {
                            NoteId = note.NoteId,
                            Title = note.Title,
                            NoteDescription = note.NoteDescription,
                            CreateAt = note.CreateAt
                        } : null
                    };
                    return every;
                },
                splitOn: "bonsaiId,categoryId,styleId,noteId"
            )
            ;
            return fullInfosUser;
        }



        public async Task<IEnumerable<EveryDTO>?> InfosPaginated(int startIndex, int pageSize, CancellationToken cancellationToken)
        {
            string sql = @"
        SELECT 
            u.Id AS UserId, u.Name AS UserName, u.Role, u.IdPictureProfil,
            b.Id AS BonsaiId, b.Name AS BonsaiName, b.Description AS BonsaiDescription, b.IdUser AS BonsaiUserId,
            c.Id AS CategoryId, c.Shohin, c.Mame, c.Chokkan, c.Moyogi, c.Shakan, c.Kengai, c.HanKengai, c.Ikadabuki, c.Neagari, c.Literati, c.YoseUe, c.Ishitsuki, c.Kabudachi, c.Kokufu, c.Yamadori, c.Perso AS CategoryPerso, c.IdBonsai,
            s.Id AS StyleID, Bunjin, s.Bankan, s.Korabuki, s.Ishituki, s.Perso AS StylePerso, s.IdBonsai,
            n.Id AS NoteId, n.Title, n.Description AS NoteDescription, n.CreateAt, n.IdBonsai
        FROM [dbo].[User] u
        LEFT JOIN [dbo].[Bonsai] b ON u.Id = b.IdUser
        LEFT JOIN [dbo].[Category] c ON b.Id = c.IdBonsai
        LEFT JOIN [dbo].[Style] s ON b.Id = s.IdBonsai
        LEFT JOIN [dbo].[Note] n ON b.Id = n.IdBonsai
        ORDER BY u.Id
        OFFSET @StartIndex ROWS FETCH NEXT @PageSize ROWS ONLY";

            //Ici je map
            var fullInfosUser = await _connection.QueryAsync<UserJoinDTO, BonsaiJoinDTO, CategoryJoinDTO, StyleJoinDTO, NoteJoinDTO, EveryDTO>(
                sql,
                (user, bonsai, category, style, note) =>
                {
                    EveryDTO every = new()
                    {
                        User = new UserJoinDTO // Ici User ne peut pas être null
                        {
                            UserId = user.UserId,
                            UserName = user.UserName,
                            Role = user.Role,
                            IdPictureProfil = user.IdPictureProfil
                        },
                        Bonsai = bonsai != null ? new BonsaiJoinDTO
                        {
                            BonsaiId = bonsai.BonsaiId,
                            BonsaiName = bonsai.BonsaiName,
                            BonsaiDescription = bonsai.BonsaiDescription,
                            BonsaiUserId = bonsai.BonsaiUserId
                        } : null,
                        Category = category != null ? new CategoryJoinDTO
                        {
                            CategoryId = category.CategoryId,
                            Shohin = category.Shohin,
                            Mame = category.Mame,
                            Chokkan = category.Chokkan,
                            Moyogi = category.Moyogi,
                            Shakan = category.Shakan,
                            Kengai = category.Kengai,
                            HanKengai = category.HanKengai,
                            Ikadabuki = category.Ikadabuki,
                            Neagari = category.Neagari,
                            Literati = category.Literati,
                            YoseUe = category.YoseUe,
                            Ishitsuki = category.Ishitsuki,
                            Kabudachi = category.Kabudachi,
                            Kokufu = category.Kokufu,
                            Yamadori = category.Yamadori,
                            CategoryPerso = category.CategoryPerso
                        } : null,
                        Style = style != null ? new StyleJoinDTO
                        {
                            StyleId = style.StyleId,
                            Bunjin = style.Bunjin,
                            Bankan = style.Bankan,
                            Korabuki = style.Korabuki,
                            Ishituki = style.Ishituki,
                            StylePerso = style.StylePerso
                        } : null,
                        Note = note != null ? new NoteJoinDTO
                        {
                            NoteId = note.NoteId,
                            Title = note.Title,
                            NoteDescription = note.NoteDescription,
                            CreateAt = note.CreateAt
                        } : null
                    };
                    return every;
                },
                new { StartIndex = startIndex, PageSize = pageSize },
                splitOn: "bonsaiId,categoryId,styleId,noteId"
            )
            ;
            return fullInfosUser;
        }

    }
}
