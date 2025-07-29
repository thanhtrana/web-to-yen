using System.ComponentModel.DataAnnotations;

namespace WebToYen.Models.ViewModels
{
    public class LoginViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui Lòng Nhập Email"), EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password), Required(ErrorMessage = "Vui Lòng Nhập Mật Khẩu")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
