using System;
using System.Collections.Generic;
using System.Globalization;

namespace PcmLesson01
{
    internal class StudentConsoleView
    {
        // =====================================================
        // NHẬP SINH VIÊN
        // =====================================================
        public Student NhapSinhVien(List<Student> students)
        {
            Student sv = new Student();

            // Nhập mã sinh viên
            while (true)
            {
                Console.Write("Mã sinh viên: ");
                sv.masv = Console.ReadLine();

                if (!StudentValidator.KiemTraMaSinhVien(sv.masv))
                {
                    Console.WriteLine("Mã sinh viên không được để trống!");
                    continue;
                }

                if (!StudentValidator.KiemTraMaKhongTrung(
                    students, sv.masv))
                {
                    Console.WriteLine("Mã sinh viên đã tồn tại!");
                    continue;
                }

                break;
            }

            // Nhập họ tên
            while (true)
            {
                Console.Write("Họ và tên: ");
                sv.hoTen = Console.ReadLine();

                if (!StudentValidator.KiemTraHoTen(sv.hoTen))
                {
                    Console.WriteLine("Họ tên không được để trống!");
                    continue;
                }

                break;
            }

            // Nhập ngày sinh
            while (true)
            {
                Console.Write("Ngày sinh (dd/MM/yyyy): ");
                string ngaySinh = Console.ReadLine();

                if (DateTime.TryParseExact(
                    ngaySinh,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime ngay))
                {
                    sv.ngaySinh = ngay;
                    break;
                }

                Console.WriteLine(
                    "Ngày sinh không hợp lệ! Ví dụ: 14/07/2006");
            }

            // Nhập giới tính
            while (true)
            {
                Console.Write("Giới tính (Nam/Nữ): ");
                string gioiTinh = Console.ReadLine();

                if (gioiTinh.Equals(
                    "Nam",
                    StringComparison.OrdinalIgnoreCase))
                {
                    sv.gioiTinh = true;
                    break;
                }

                if (gioiTinh.Equals(
                    "Nữ",
                    StringComparison.OrdinalIgnoreCase))
                {
                    sv.gioiTinh = false;
                    break;
                }

                Console.WriteLine("Chỉ được nhập Nam hoặc Nữ!");
            }

            // Nhập email
            while (true)
            {
                Console.Write("Email: ");
                sv.email = Console.ReadLine();

                if (!StudentValidator.KiemTraEmail(sv.email))
                {
                    Console.WriteLine("Email không đúng định dạng!");
                    continue;
                }

                break;
            }

            // Nhập số điện thoại
            while (true)
            {
                Console.Write("Số điện thoại: ");
                sv.soDienThoai = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(sv.soDienThoai))
                {
                    Console.WriteLine(
                        "Số điện thoại không được để trống!");
                    continue;
                }

                break;
            }

            // Nhập ngành
            while (true)
            {
                Console.Write("Ngành: ");
                sv.nganh = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(sv.nganh))
                {
                    Console.WriteLine("Ngành không được để trống!");
                    continue;
                }

                break;
            }

            // Nhập điểm trung bình
            while (true)
            {
                Console.Write("Điểm trung bình: ");
                string diem = Console.ReadLine();

                if (!float.TryParse(diem, out float dtb))
                {
                    Console.WriteLine(
                        "Điểm phải là một số!");
                    continue;
                }

                if (!StudentValidator.KiemTraDiem(dtb))
                {
                    Console.WriteLine(
                        "Điểm phải nằm trong khoảng từ 0 đến 10!");
                    continue;
                }

                sv.diemTrungBinh = dtb;
                break;
            }

            // Nhập trạng thái
            while (true)
            {
                Console.Write(
                    "Trạng thái (Đang học/Đã tốt nghiệp): ");

                string trangThai = Console.ReadLine();

                if (trangThai.Equals(
                    "Đang học",
                    StringComparison.OrdinalIgnoreCase))
                {
                    sv.trangThai = true;
                    break;
                }

                if (trangThai.Equals(
                    "Đã tốt nghiệp",
                    StringComparison.OrdinalIgnoreCase))
                {
                    sv.trangThai = false;
                    break;
                }

                Console.WriteLine(
                    "Chỉ được nhập Đang học hoặc Đã tốt nghiệp!");
            }

            return sv;
        }


        // =====================================================
        // HIỂN THỊ MỘT SINH VIÊN
        // =====================================================
        public void HienThiSinhVien(Student sv)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Mã sinh viên: " + sv.masv);
            Console.WriteLine("Họ và tên: " + sv.hoTen);
            Console.WriteLine(
                "Ngày sinh: " +
                sv.ngaySinh.ToString("dd/MM/yyyy"));
            Console.WriteLine(
                "Giới tính: " +
                (sv.gioiTinh ? "Nam" : "Nữ"));
            Console.WriteLine("Email: " + sv.email);
            Console.WriteLine(
                "Số điện thoại: " + sv.soDienThoai);
            Console.WriteLine("Ngành: " + sv.nganh);
            Console.WriteLine(
                "Điểm trung bình: " +
                sv.diemTrungBinh);
            Console.WriteLine(
                "Trạng thái: " +
                (sv.trangThai
                    ? "Đang học"
                    : "Đã tốt nghiệp"));
        }


        // =====================================================
        // HIỂN THỊ DANH SÁCH
        // =====================================================
        public void HienThiDanhSach(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine(
                    "Danh sách sinh viên đang trống!");
                return;
            }

            Console.WriteLine(
                "\n========== DANH SÁCH SINH VIÊN ==========");

            foreach (Student sv in students)
            {
                HienThiSinhVien(sv);
            }

            Console.WriteLine("----------------------------------------");
        }
    }
}