using System.ComponentModel.DataAnnotations;


namespace BLL_DokiHouse.Models.User
{
    public class UserCheckActualMail
    {
        [Required(ErrorMessage = $"{nameof(Mail)} : champ requis")]
        [DataType(DataType.EmailAddress, ErrorMessage = $"{nameof(Mail)} : champ requis, {nameof(Mail)} : non valide !")]
        [EmailAddress(ErrorMessage = $"{nameof(Mail)} : champ requis, {nameof(Mail)} : non valide !")]
        public string Mail { get; set; } = string.Empty;
    }
}
