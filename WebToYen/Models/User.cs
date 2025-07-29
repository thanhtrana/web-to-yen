using System.ComponentModel.DataAnnotations;

namespace WebToYen.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Vui Lòng Nhập Tên Tài Khoản")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Vui Lòng Nhập Email"), EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password),Required(ErrorMessage = "Vui Lòng Nhập Mật Khẩu")]
        public string Password { get; set; }

        
    }
}
