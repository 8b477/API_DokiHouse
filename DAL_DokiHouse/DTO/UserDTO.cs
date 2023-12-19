using System.ComponentModel.DataAnnotations;


namespace DAL_DokiHouse.DTO
{
    public record class UserDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Passwd { get; set; } = string.Empty;
        public byte[]? Picture { get; set; }
        public string? Role { get; set; }
    }


    public record class UserCreateDTO
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Passwd { get; set; }
    }


    public record class UserCreateDTOPassConfirm
    {
        [Required(ErrorMessage = $"{nameof(Name)} : champ requis")]
        [MinLength(3, ErrorMessage = $"Le champ {nameof(Name)} est requis et doit comporter au min 3 caratères")]
        [MaxLength(20, ErrorMessage = $"Le champ {nameof(Name)} est requis et doit comporter au max 20 caratères")]
        public string Name { get; set; }

        [Required(ErrorMessage = $"{nameof(Email)} : champ requis")]
        [DataType(DataType.EmailAddress, ErrorMessage = $"{nameof(Email)} : champ requis, {nameof(Email)} : non valide !")]
        public string Email { get; set; }

        [Required(ErrorMessage = $"{nameof(Passwd)} : champ requis")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = $"8 caractères mini, 1 majuscule, 1 minuscule, 1 chiffre et 1 caractère spécial")]
        public string Passwd { get; set; }

        [Required(ErrorMessage = $"{nameof(PasswdConfirm)} : champ requis")]
        [Compare(nameof(Passwd), ErrorMessage = "Les pass ne corresponde pas !")]
        public string PasswdConfirm { get; set; }
    }


    public record class UserUpdateDTO
    {
        [Required(ErrorMessage = $"{nameof(Name)} : champ requis")]
        [MinLength(3, ErrorMessage = $"Le champ {nameof(Name)} est requis et doit comporter au min 3 caratères")]
        [MaxLength(20, ErrorMessage = $"Le champ {nameof(Name)} est requis et doit comporter au max 20 caratères")]
        public string Name { get; set; }

        [Required(ErrorMessage = $"{nameof(Email)} : champ requis")]
        [DataType(DataType.EmailAddress, ErrorMessage = $"{nameof(Email)} : champ requis, {nameof(Email)} : non valide !")]
        public string Email { get; set; }

        [Required(ErrorMessage = $"{nameof(Passwd)} : champ requis")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = $"8 caractères mini, 1 majuscule, 1 minuscule, 1 chiffre et 1 caractère spécial")]
        public string Passwd { get; set; }
    }


    public record class UserDisplayDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public byte[]? Picture { get; set; }
    }


    public record class ADMIN_UserDisplayDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Passwd { get; set; } = string.Empty;
        public byte[]? Picture { get; set; }
        public string? Role { get; set; }
    }
}

// A TEST POUR LE FICHIER
//[DataType((DataType)((byte)DataType.Upload), ErrorMessage = $"{nameof(Picture)} : Type de fichier non compatible")]
//public byte[]? Picture { get; set; }