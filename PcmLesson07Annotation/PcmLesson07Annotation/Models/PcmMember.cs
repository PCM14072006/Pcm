using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PcmLesson07Annotation.Models
{
    public class PcmMember
    {
        public int Id { get; set; }

        [DisplayName("Tài khoản")]
        [Required(ErrorMessage = "Tài khoản không được để trống")]
        [StringLength(20, MinimumLength = 3,
            ErrorMessage = "Tài khoản có độ dài khoảng 3-20 kí tự")]
        public string PcmUsername { get; set; } = string.Empty;

        [DisplayName("Password")]
        [StringLength(100, MinimumLength = 8,ErrorMessage = "Mật khẩu tối thiểu 8 ký tự")]
        public string Pcmpassword { get; set; } = string.Empty;

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email không được để trống")]
        [DataType(DataType.EmailAddress)]
        public string PcmEmail { get; set; } = string.Empty;

        [DisplayName("Điện thoại")]
        [Required(ErrorMessage = "Bạn chưa nhập điện thoại")]
        [RegularExpression(@"^0\d{9}$",
            ErrorMessage = "Điện thoại phải là 10 ký tự số, bắt đầu bằng số 0")]
        public string PcmPhone { get; set; } = string.Empty;
    }
}