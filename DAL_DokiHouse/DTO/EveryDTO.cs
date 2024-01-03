namespace DAL_DokiHouse.DTO
{

    public class EveryDTO
    {
        public EveryDTO()
        {

        }

        public UserJoinDTO User { get; set; }

        public BonsaiJoinDTO? Bonsai { get; set; }

        public CategoryJoinDTO? Category { get; set; }

        public StyleJoinDTO? Style { get; set; }

        public NoteJoinDTO? Note { get; set; }
    }


    //public class FullDTO
    //    {
    //        public FullDTO() { }

    //        public FullDTO(int userId, string userName, string role, int? idPictureProfil, int bonsaiId, string bonsaiName, string? bonsaiDescription, int bonsaiUserId, int categoryId, bool shohin, bool mame, bool chokkan, bool moyogi, bool shakan, bool kengai, bool hanKengai, bool ikadabuki, bool neagari, bool literati, bool yoseUe, bool ishitsuki, bool kabudachi, bool kokufu, bool yamadori, string? categoryPerso, int styleId, bool bunjin, bool bankan, bool korabuki, bool ishituki, string? stylePerso, int noteId, string title, string noteDescription, DateTime createAt)
    //        {
    //            UserId = userId;
    //            UserName = userName;
    //            Role = role;
    //            IdPictureProfil = idPictureProfil;
    //            BonsaiId = bonsaiId;
    //            BonsaiName = bonsaiName;
    //            BonsaiDescription = bonsaiDescription;
    //            BonsaiUserId = bonsaiUserId;
    //            CategoryId = categoryId;
    //            Shohin = shohin;
    //            Mame = mame;
    //            Chokkan = chokkan;
    //            Moyogi = moyogi;
    //            Shakan = shakan;
    //            Kengai = kengai;
    //            HanKengai = hanKengai;
    //            Ikadabuki = ikadabuki;
    //            Neagari = neagari;
    //            Literati = literati;
    //            YoseUe = yoseUe;
    //            Ishitsuki = ishitsuki;
    //            Kabudachi = kabudachi;
    //            Kokufu = kokufu;
    //            Yamadori = yamadori;
    //            CategoryPerso = categoryPerso;
    //            StyleId = styleId;
    //            Bunjin = bunjin;
    //            Bankan = bankan;
    //            Korabuki = korabuki;
    //            Ishituki = ishituki;
    //            StylePerso = stylePerso;
    //            NoteId = noteId;
    //            Title = title;
    //            NoteDescription = noteDescription;
    //            CreateAt = createAt;
    //        }


    //        // User
    //        public int UserId { get; set; }
    //        public string UserName { get; set; }
    //        public string Role { get; set; }
    //        public int? IdPictureProfil { get; set; }

    //        // Bonsai
    //        public int BonsaiId { get; set; }
    //        public string BonsaiName { get; set; }
    //        public string? BonsaiDescription { get; set; }
    //        public int BonsaiUserId { get; set; }

    //        // Category
    //        public int CategoryId { get; set; }
    //        public bool Shohin { get; set; }
    //        public bool Mame { get; set; }
    //        public bool Chokkan { get; set; }
    //        public bool Moyogi { get; set; }
    //        public bool Shakan { get; set; }
    //        public bool Kengai { get; set; }
    //        public bool HanKengai { get; set; }
    //        public bool Ikadabuki { get; set; }
    //        public bool Neagari { get; set; }
    //        public bool Literati { get; set; }
    //        public bool YoseUe { get; set; }
    //        public bool Ishitsuki { get; set; }
    //        public bool Kabudachi { get; set; }
    //        public bool Kokufu { get; set; }
    //        public bool Yamadori { get; set; }
    //        public string? CategoryPerso { get; set; }

    //        // Style
    //        public int StyleId { get; set; }
    //        public bool Bunjin { get; set; }
    //        public bool Bankan { get; set; }
    //        public bool Korabuki { get; set; }
    //        public bool Ishituki { get; set; }
    //        public string? StylePerso { get; set; }

    //        // Note
    //        public int NoteId { get; set; }
    //        public string Title { get; set; }
    //        public string NoteDescription { get; set; }
    //        public DateTime CreateAt { get; set; }
    //    }


    public class BonsaiJoinDTO
    {
        public BonsaiJoinDTO() { }

        public int BonsaiId { get; set; }
        public string BonsaiName { get; set; }
        public string? BonsaiDescription { get; set; }
        public int BonsaiUserId { get; set; }
    }


    public class CategoryJoinDTO
    {

        public CategoryJoinDTO() { }

        public int CategoryId { get; set; }
        public bool Shohin { get; set; }
        public bool Mame { get; set; }
        public bool Chokkan { get; set; }
        public bool Moyogi { get; set; }
        public bool Shakan { get; set; }
        public bool Kengai { get; set; }
        public bool HanKengai { get; set; }
        public bool Ikadabuki { get; set; }
        public bool Neagari { get; set; }
        public bool Literati { get; set; }
        public bool YoseUe { get; set; }
        public bool Ishitsuki { get; set; }
        public bool Kabudachi { get; set; }
        public bool Kokufu { get; set; }
        public bool Yamadori { get; set; }
        public string? CategoryPerso { get; set; }
    }

    public class UserJoinDTO
    {
        public UserJoinDTO()
        {

        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public int? IdPictureProfil { get; set; }
    }

    public class StyleJoinDTO
    {
        public StyleJoinDTO()
        {

        }

        public int StyleId { get; set; }
        public bool Bunjin { get; set; }
        public bool Bankan { get; set; }
        public bool Korabuki { get; set; }
        public bool Ishituki { get; set; }
        public string? StylePerso { get; set; }
    }


    public class NoteJoinDTO
    {
        public NoteJoinDTO()
        {

        }

        public int NoteId { get; set; }
        public string Title { get; set; }
        public string NoteDescription { get; set; }
        public DateTime CreateAt { get; set; }
    }

}