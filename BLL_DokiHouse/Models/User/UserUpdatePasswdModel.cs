using System.ComponentModel.DataAnnotations;


namespace BLL_DokiHouse.Models.User
{
    public class UserUpdatePasswdModel
    {
        [Required(ErrorMessage = $"{nameof(Passwd)} : champ requis")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = $"8 caractères mini, 1 majuscule, 1 minuscule, 1 chiffre et 1 caractère spécial")]
        public string Passwd { get; set; } = string.Empty;

        [Required]
        [Compare(nameof(Passwd))]
        public string PassConfirm { get; set; } = string.Empty;
    }
}
