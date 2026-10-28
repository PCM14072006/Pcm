using System;
using System.ComponentModel.DataAnnotations;

namespace PcmTh01.Models
{
    public class Student
    {
        [Display(Name = "Mã sinh viên")]
        public int Id { get; set; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "{0} bắt buộc phải được nhập")]
        [StringLength(100, MinimumLength = 4,
            ErrorMessage = "{0} phải có từ {2} đến {1} ký tự")]
        public string? Name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} bắt buộc phải được nhập")]
        [RegularExpression(
            @"^[A-Za-z0-9._%+-]+@gmail\.com$",
            ErrorMessage = "{0} phải có đuôi @gmail.com")]
        public string? Email { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "{0} bắt buộc phải được nhập")]
        [StringLength(100, MinimumLength = 8,
            ErrorMessage = "{0} phải có từ {2} ký tự trở lên")]
        [RegularExpression(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z0-9]).{8,}$",
            ErrorMessage = "{0} phải có ký tự viết hoa, viết thường, chữ số và ký tự đặc biệt")]
        public string? Password { get; set; }

        [Display(Name = "Ngành học")]
        [Required(ErrorMessage = "{0} bắt buộc phải được chọn")]
        public Branch? Branch { get; set; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "{0} bắt buộc phải được chọn")]
        public Gender? Gender { get; set; }

        [Display(Name = "Hệ đào tạo")]
        public bool IsRegular { get; set; }

        [Display(Name = "Địa chỉ")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "{0} bắt buộc phải được nhập")]
        public string? Address { get; set; }

        [Display(Name = "Ngày sinh")]
        [Range(typeof(DateTime), "1963-01-01", "2005-12-31",
            ErrorMessage = "{0} phải nằm trong khoảng từ 01/01/1963 đến 31/12/2005")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} bắt buộc phải được nhập")]
        public DateTime DateOfBorth { get; set; }

        [Display(Name = "Điểm")]
        [Required(ErrorMessage = "{0} bắt buộc phải được nhập")]
        [Range(0.0, 10.0, ErrorMessage = "{0} phải nằm trong khoảng từ {1} đến {2}")]
        public double? Score { get; set; }

        [Display(Name = "Ảnh sinh viên")]
        public string? Image { get; set; }
    }
}