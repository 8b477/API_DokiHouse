using System.ComponentModel.DataAnnotations;

namespace API_DokiHouse.Models
{
    public record UserCreateModel
    {
        [Required(ErrorMessage = $"{nameof(Name)} : champ requis")]
        [MinLength(3, ErrorMessage = $"Le champ {nameof(Name)} est requis et doit comporter au min 3 caratères")]
        [MaxLength(20, ErrorMessage = $"Le champ {nameof(Name)} est requis et doit comporter au max 20 caratères")]
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
        [Compare(nameof(Passwd), ErrorMessage = "Les pass ne corresponde pas !")]
        public string PasswdConfirm { get; set; } = string.Empty;
    }

    public record UserUpdateModel
    {
        [Required(ErrorMessage = $"{nameof(Name)} : champ requis")]
        [MinLength(3, ErrorMessage = $"Le champ {nameof(Name)} est requis et doit comporter au min 3 caratères")]
        [MaxLength(20, ErrorMessage = $"Le champ {nameof(Name)} est requis et doit comporter au max 20 caratères")]
        public string Name { get; set; } = string.Empty;


        [Required(ErrorMessage = $"{nameof(Passwd)} : champ requis")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = $"8 caractères mini, 1 majuscule, 1 minuscule, 1 chiffre et 1 caractère spécial")]
        public string Passwd { get; set; } = string.Empty;

        [Required(ErrorMessage = $"{nameof(PasswdConfirm)} : champ requis")]
        [Compare(nameof(Passwd), ErrorMessage = "Les pass ne corresponde pas !")]
        public string PasswdConfirm { get; set; } = string.Empty;
    }

    public record UserLoginModel
    {
        [Required(ErrorMessage = $"{nameof(Email)} : champ requis")]
        [DataType(DataType.EmailAddress, ErrorMessage = $"{nameof(Email)} : champ requis, {nameof(Email)} : non valide !")]
        [EmailAddress(ErrorMessage = $"{nameof(Email)} : champ requis, {nameof(Email)} : non valide !")]

        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = $"{nameof(Passwd)} : champ requis")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = $"8 caractères mini, 1 majuscule, 1 minuscule, 1 chiffre et 1 caractère spécial")]

        public string Passwd { get; set; } = string.Empty;
    }

    public record UserModelDisplay
    {
        public UserModelDisplay(int id, string name, string role, int? idPicture)
        {
            Id = id;
            Name = name;
            Role = role;
            IdPicture = idPicture;
        }

        public int Id { get; }
        public string Name { get; } = string.Empty;
        public string Role { get; } = string.Empty;
        public int? IdPicture { get; }
    }

}
