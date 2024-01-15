using API_DokiHouse.Models;
using BLL_DokiHouse.Models.FilePicture;
using BLL_DokiHouse.Models.User;
using Entities_DokiHouse.Entities;

namespace BLL_DokiHouse.Tools
{
    internal class Mapping
    {

        #region Bonsai
        // Ajout de la date de création
        public static Bonsai BonsaiCreateBLLtoDAL(BonsaiModel bonsaiBLL)
        {
            return new() 
            {
                Name = bonsaiBLL.Name,
                Description = bonsaiBLL.Description,
                CreateAt = DateTime.Now,
                ModifiedAt = null
            };
        }


        // Ajout de la date de modification
        public static Bonsai BonsaiUpdateBLLtoDAL(BonsaiModel bonsaiBLL)
        {
            return new()
            {
                Name = bonsaiBLL.Name,
                ModifiedAt = DateTime.Now,
                Description = bonsaiBLL.Description
            };
        }

        #endregion


        #region Category
        // Ajout de la date de création
        public static Category CategoryCreateBLLToDAL(CategoryModel category)
        {
            return new()
            {
                Chokkan = category.Chokkan,
                HanKengai = category.HanKengai,
                Ikadabuki = category.Ikadabuki,
                Ishitsuki = category.Ishitsuki,
                Kabudachi = category.Kabudachi,
                Kengai = category.Kengai,
                Kokufu = category.Kokufu,
                Literati = category.Literati,
                Mame = category.Mame,
                Moyogi = category.Moyogi,
                Neagari = category.Neagari,
                Shakan = category.Shakan,
                Shohin = category.Shohin,
                Yamadori = category.Yamadori,
                YoseUe = category.YoseUe,
                CatePerso = category.Perso,
                CreatedAt = DateTime.Now,
                ModifiedAt = null
            };
        }


        // Ajout de la date de modification
        public static Category CategoryUpdateBLLToDAL(CategoryModel category)
        {
            return new()
            {
                Chokkan = category.Chokkan,
                HanKengai = category.HanKengai,
                Ikadabuki = category.Ikadabuki,
                Ishitsuki = category.Ishitsuki,
                Kabudachi = category.Kabudachi,
                Kengai = category.Kengai,
                Kokufu = category.Kokufu,
                Literati = category.Literati,
                Mame = category.Mame,
                Moyogi = category.Moyogi,
                Neagari = category.Neagari,
                Shakan = category.Shakan,
                Shohin = category.Shohin,
                Yamadori = category.Yamadori,
                YoseUe = category.YoseUe,
                CatePerso = category.Perso,
                ModifiedAt = DateTime.Now
            };
        }
        #endregion


        #region Comments

        // Ajout de la date de création
        public static Comments CommentCreateBLLToDAL(CommentModel comment)
        {
            return new()
            { 
                Content = comment.Content,
                CreatedAt = DateTime.Now,
                ModifiedAt = null
            };
        }


        // Ajout de la date de modification
        public static Comments CommentUpdateBLLToDAL(CommentModel comment)
        {
            return new()
            {
                Content = comment.Content,
                ModifiedAt = DateTime.Now,
            };
        }

        #endregion


        #region Note

        // Ajout de la date de création
        public static Note NoteCreateBLLtoDAL(NoteModel note)
        {
            return new()
            {
                Title = note.Title,
                Description = note.Description,          
                CreatedAt = DateTime.Now,
                ModifiedAt = null
            };
        }


        // Ajout de la date de modification
        public static Note NoteUpdateBLLtoDAL(NoteModel note)
        {
            return new()
            {
                ModifiedAt = DateTime.Now,
                Title = note.Title,
                Description = note.Description
            };
        }
        #endregion


        #region Picture

        // Ajout de la date de création
        public static PictureBonsai FilePictureCreateToDAL(FilePictureModel filePicture)
        {
            return new()
            {
                FileName = filePicture.FileName,
                CreatedAt = DateTime.Now,
                ModifiedAt = null
                
            };
        }

        // Ajout de la date de modification
        public static PictureBonsai FilePictureUpdateToDAL(FilePictureModel filePicture) 
        {
            return new()
            {
                FileName = filePicture.FileName,
                ModifiedAt = DateTime.Now
            };
        }

        #endregion


        #region Post

        // Ajout de la date de création
        public static Post PostCreateBLLToDAL(PostModel post)
        {
            return new()
            {
                Title = post.Title,
                Content = post.Content,
                Description = post.Description,
                CreateAt = DateTime.Now,
                ModifiedAt = null
            };
        }

        // Ajout de la date de modification
        public static Post PostUpdateBLLToDAL(PostModel post)
        {
            return new()
            {
                Title = post.Title,
                Content = post.Content,
                Description = post.Description,
                ModifiedAt = DateTime.Now,
            };
        }
        #endregion


        #region Style

        // Ajout de la date de création
        public static Style StyleCreateBLLToDAL(StyleModel style)
        {
            return new()
            {
                Bankan = style.Bankan,
                Bunjin = style.Bunjin,
                Ishituki = style.Ishituki,
                Korabuki = style.Korabuki,
                StylePerso = style.Perso,
                CreatedAt = DateTime.Now,    
                ModifiedAt = null
            };
        }


        // Ajout de la date de modification
        public static Style StyleUpdateBLLToDAL(StyleModel style)
        {
            return new()
            {
                Bankan = style.Bankan,
                Bunjin = style.Bunjin,
                Ishituki = style.Ishituki,
                Korabuki = style.Korabuki,
                StylePerso = style.Perso,
                ModifiedAt = DateTime.Now,
            };
        }
        #endregion

        #region User

        // Ajout de la date de création
        public static User UserCreateBLLToDAL(UserCreateModel user)
        {
            return new()
            {
                Name = user.Name,
                Email = user.Email,
                Passwd = user.Passwd,
                Role = "Visitor",
                CreatedAt = DateTime.Now,
                ModifiedAt = null
            };
        }

        // UPDATE FULL
        // Ajout de la date de modification
        public static User UserUpdateBLLToDAL(UserUpdateModel user)
        {
            return new()
            {
                Name = user.Name,
                Email = user.Email,
                Passwd = user.Passwd,
                Role = "Visitor",
                ModifiedAt = DateTime.Now
            };
        }


        // UPDATE NAME
        // Ajout de la date de modification
        public static User UserUpdateNameBLLToDAL(UserUpdateNameModel user)
        {
            return new()
            {
                Name = user.Name,
                ModifiedAt = DateTime.Now
            };
        }


        // UPDATE PASS
        // Ajout de la date de modification
        public static User UserUpdatePassBLLToDAL(UserUpdatePasswdModel user)
        {
            return new()
            {
                Passwd = user.Passwd,
                ModifiedAt = DateTime.Now
            };
        }


        // UPDATE EMAIL
        // Ajout de la date de modification
        public static User UserUpdateEmailBLLToDAL(UserUpdateEmailModel user)
        {
            return new()
            {
                Email = user.Email,
                ModifiedAt = DateTime.Now
            };
        }
        #endregion
    }
}
