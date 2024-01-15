using System.ComponentModel.DataAnnotations;

namespace BLL_DokiHouse.Models.User
{
    public class UserUpdateEmailModel
    {
        [Required(ErrorMessage = $"{nameof(Email)} : champ requis")]
        [DataType(DataType.EmailAddress, ErrorMessage = $"{nameof(Email)} : champ requis, {nameof(Email)} : non valide !")]
        [EmailAddress(ErrorMessage = $"{nameof(Email)} : champ requis, {nameof(Email)} : non valide !")]
        public string Email { get; set; } = string.Empty;
    }
}
