using DAL_DokiHouse.DTO.Bonsai;
using DAL_DokiHouse.DTO.User;
using DAL_DokiHouse.Interfaces;
using Dapper;
using Entities_DokiHouse.Entities;
using System.Data;


namespace DAL_DokiHouse.Repository
{
    public class UserBonsaiRepo : IUserBonsaiRepo
    {

        #region INJECTION
        private readonly IDbConnection _connection;
        public UserBonsaiRepo(IDbConnection connection) => _connection = connection;
        #endregion


        public async Task<IEnumerable<UserAndBonsaiDetails?>> GetInfos(int startIndex, int pageSize)
        {
            string sql = @"
            SELECT 
                u.Id,
                u.Name,
                u.CreateAt,
                u.ModifiedAt,

                pu.Id,
                pu.Avatar,
                pu.CreateAt,
                pu.ModifiedAt,

                b.Id,
                b.Name,
                b.IdUser,
                b.CreateAt,
                b.ModifiedAt,

                pb.Id,
                pb.FileName,
                pb.CreateAt,
                pb.ModifiedAt,
                pb.IdBonsai,

                c.Id, 
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
                c.Perso AS CatePerso,
                c.IdBonsai,
                c.CreateAt,
                c.ModifiedAt,

                s.Id,
                s.Bunjin,
                s.Bankan,
                s.Korabuki,
                s.Ishituki,
                s.Perso AS StylePerso,
                s.CreateAt,
                s.ModifiedAt,
                s.IdBonsai,

                n.Id,
                n.Title,
                n.Description,
                n.CreateAt,
                n.ModifiedAt,
                n.IdBonsai

            FROM [dbo].[User] u
            LEFT JOIN [dbo].[PictureProfil] pu ON pu.IdUser = u.Id
            LEFT JOIN [dbo].[Bonsai] b ON b.IdUser = u.Id
            LEFT JOIN [dbo].[PictureBonsai] pb ON pb.IdBonsai = b.Id
            LEFT JOIN [dbo].[Category] c ON c.IdBonsai = b.Id
            LEFT JOIN [dbo].[Style] s ON s.IdBonsai = b.Id
            LEFT JOIN [dbo].[Note] n ON n.IdBonsai = b.Id
            ORDER BY u.Id
            OFFSET @StartIndex ROWS FETCH NEXT @PageSize ROWS ONLY";


            var userDictionary = new Dictionary<int, UserAndBonsaiDetails>();

            await _connection.QueryAsync<UserAndBonsaiDetails, PictureProfil, BonsaiDetailsDTO, PictureBonsai, Category, Style, Note, UserAndBonsaiDetails>(
                sql,
                (user, pictureProfil, bonsai, pictureBonsai, category, style, note) =>
                {
                    if (!userDictionary.TryGetValue(user.Id, out var existingUser))
                    {
                        existingUser = user;
                        existingUser.BonsaiDetails = new List<BonsaiDetailsDTO>();
                        userDictionary.Add(existingUser.Id, existingUser);
                    }

                    user.PictureProfil = pictureProfil;

                    if (bonsai is not null)
                    {
                        bonsai.PictureBonsai = pictureBonsai;
                        bonsai.Categories = category;
                        bonsai.Styles = style;
                        bonsai.Notes = note;
                    }

                    if (existingUser.BonsaiDetails is not null)
                    {
                        // Ajoute le bonsai uniquement s'il n'existe pas déjà dans la liste, pour éviter les doublons
                        if (bonsai is not null && !existingUser.BonsaiDetails.Any(b => b.Id == bonsai.Id))
                        {
                            existingUser.BonsaiDetails.Add(bonsai);
                        }
                    }

                    return existingUser;
                }, new { StartIndex = startIndex, PageSize = pageSize },
                splitOn: "Id");

            return userDictionary.Values;
        }


        public async Task<UserAndBonsaiDetails?> GetInfosById(int idUser)
        {
            string sql = @"
            SELECT 
                u.Id,
                u.Name,
                u.CreateAt,
                u.ModifiedAt,

                pu.Id,
                pu.Avatar,
                pu.CreateAt,
                pu.ModifiedAt,

                b.Id,
                b.Name,
                b.IdUser,
                b.CreateAt,
                b.ModifiedAt,

                pb.Id,
                pb.FileName,
                pb.CreateAt,
                pb.ModifiedAt,
                pb.IdBonsai,

                c.Id, 
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
                c.Perso AS CatePerso,
                c.IdBonsai,
                c.CreateAt,
                c.ModifiedAt,

                s.Id,
                s.Bunjin,
                s.Bankan,
                s.Korabuki,
                s.Ishituki,
                s.Perso AS StylePerso,
                s.CreateAt,
                s.ModifiedAt,
                s.IdBonsai,

                n.Id,
                n.Title,
                n.Description,
                n.CreateAt,
                n.ModifiedAt,
                n.IdBonsai

            FROM [dbo].[User] u
            LEFT JOIN [dbo].[PictureProfil] pu ON pu.IdUser = u.Id
            LEFT JOIN [dbo].[Bonsai] b ON b.IdUser = u.Id
            LEFT JOIN [dbo].[PictureBonsai] pb ON pb.IdBonsai = b.Id
            LEFT JOIN [dbo].[Category] c ON c.IdBonsai = b.Id
            LEFT JOIN [dbo].[Style] s ON s.IdBonsai = b.Id
            LEFT JOIN [dbo].[Note] n ON n.IdBonsai = b.Id
            WHERE u.Id = @IdUser";


            var userDictionary = new Dictionary<int, UserAndBonsaiDetails>();

            await _connection.QueryAsync<UserAndBonsaiDetails, PictureProfil, BonsaiDetailsDTO, PictureBonsai, Category, Style, Note, UserAndBonsaiDetails>(
                sql,
                (user, pictureProfil, bonsai, pictureBonsai, category, style, note) =>
                {
                    if (!userDictionary.TryGetValue(user.Id, out var existingUser))
                    {
                        existingUser = user;
                        existingUser.BonsaiDetails = new List<BonsaiDetailsDTO>();
                        userDictionary.Add(existingUser.Id, existingUser);
                    }

                    user.PictureProfil = pictureProfil;

                    if (bonsai is not null)
                    {
                        bonsai.PictureBonsai = pictureBonsai;
                        bonsai.Categories = category;
                        bonsai.Styles = style;
                        bonsai.Notes = note;
                    }

                    if (existingUser.BonsaiDetails is not null)
                    {
                        // Ajoute le bonsai uniquement s'il n'existe pas déjà dans la liste, pour éviter les doublons
                        if (bonsai is not null && !existingUser.BonsaiDetails.Any(b => b.Id == bonsai.Id))
                        {
                            existingUser.BonsaiDetails.Add(bonsai);
                        }
                    }

                    return existingUser;
                },
                new { IdUser = idUser },
                splitOn: "Id");

            return userDictionary.Values.FirstOrDefault();
        }


    }
}
