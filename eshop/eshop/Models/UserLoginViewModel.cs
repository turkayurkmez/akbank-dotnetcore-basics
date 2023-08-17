using System.ComponentModel.DataAnnotations;

namespace eshop.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre zorunludur.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
