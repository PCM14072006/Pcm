using System;
using System.Collections.Generic;
using System.Linq;

namespace PcmLesson01
{
    internal class StudentValidator
    {
        // Kiểm tra mã sinh viên không được để trống
        public static bool KiemTraMaSinhVien(string masv)
        {
            return !string.IsNullOrWhiteSpace(masv);
        }

        // Kiểm tra mã sinh viên không được trùng
        public static bool KiemTraMaKhongTrung(
            List<Student> students,
            string masv)
        {
            return !students.Any(s =>
                s.masv.Equals(
                    masv,
                    StringComparison.OrdinalIgnoreCase));
        }

        // Kiểm tra họ tên không được để trống
        public static bool KiemTraHoTen(string hoTen)
        {
            return !string.IsNullOrWhiteSpace(hoTen);
        }

        // Kiểm tra điểm trung bình từ 0 đến 10
        public static bool KiemTraDiem(float diem)
        {
            return diem >= 0 && diem <= 10;
        }

        // Kiểm tra email
        public static bool KiemTraEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            return email.Contains("@") && email.Contains(".");
        }

        // Kiểm tra sinh viên có tồn tại hay không
        public static bool KiemTraTonTai(
            List<Student> students,
            string masv)
        {
            return students.Any(s =>
                s.masv.Equals(
                    masv,
                    StringComparison.OrdinalIgnoreCase));
        }
    }
}