using System.ComponentModel.DataAnnotations;


namespace BLL_DokiHouse.Models.User
{
    public class UserCheckActualMail
    {
        [Required(ErrorMessage = $"{nameof(Value)} : champ requis")]
        [DataType(DataType.EmailAddress, ErrorMessage = $"{nameof(Value)} : champ requis, {nameof(Value)} : non valide !")]
        [EmailAddress(ErrorMessage = $"{nameof(Value)} : champ requis, {nameof(Value)} : non valide !")]
        public string Value { get; set; } = string.Empty;
    }
}
