using System.ComponentModel.DataAnnotations;


namespace BLL_DokiHouse.Models.User
{
    public class UserUpdateNameModel
    {
        [Required(ErrorMessage = $"{nameof(Name)} : champ requis")]
        [MinLength(3, ErrorMessage = $"Le champ {nameof(Name)} est requis et doit comporter au min 3 caractères")]
        [MaxLength(20, ErrorMessage = $"Le champ {nameof(Name)} est requis et doit comporter au max 20 caractères")]
        public string Name { get; set; } = string.Empty;
    }
}
