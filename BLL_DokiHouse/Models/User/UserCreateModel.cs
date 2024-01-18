using System.ComponentModel.DataAnnotations;

namespace BLL_DokiHouse.Models.User
{
    public class UserCreateModel
    {

        [Required(ErrorMessage = $"{nameof(Name)} : champ requis")]
        [MinLength(3, ErrorMessage = $"Le champ {nameof(Name)} est requis et doit comporter au min 3 caractères")]
        [MaxLength(20, ErrorMessage = $"Le champ {nameof(Name)} est requis et doit comporter au max 20 caractères")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = $"{nameof(Email)} : champ requis")]
        [DataType(DataType.EmailAddress, ErrorMessage = $"{nameof(Email)} : champ requis, {nameof(Email)} : non valide !")]
        [EmailAddress(ErrorMessage = $"{nameof(Email)} : champ requis, {nameof(Email)} : non valide !")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = $"{nameof(Passwd)} : champ requis")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = $"8 caractères mini, 1 majuscule, 1 minuscule, 1 chiffre et 1 caractère spécial")]
        public string Passwd { get; set; } = string.Empty;

        [Required(ErrorMessage = $"{nameof(PasswdConfirm)} : champ requis")]
        [Compare(nameof(Passwd), ErrorMessage = "Le champ Passwd et le PasswdConfirm ne corresponde pas")]
        public string PasswdConfirm { get; set; } = string.Empty;
    }
}
