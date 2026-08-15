using System;
using System.Collections.Generic;
using System.Linq;

namespace PcmLesson01
{
    internal class StudentService
    {
        private List<Student> students;

        // Constructor
        public StudentService(List<Student> students)
        {
            this.students = students;
        }

        // =====================================================
        // 1. THÊM SINH VIÊN
        // =====================================================
        public bool ThemSinhVien(Student sv)
        {
            if (!StudentValidator.KiemTraMaSinhVien(sv.masv))
            {
                Console.WriteLine("Mã sinh viên không được để trống!");
                return false;
            }

            if (!StudentValidator.KiemTraMaKhongTrung(students, sv.masv))
            {
                Console.WriteLine("Mã sinh viên đã tồn tại!");
                return false;
            }

            if (!StudentValidator.KiemTraHoTen(sv.hoTen))
            {
                Console.WriteLine("Họ tên không được để trống!");
                return false;
            }

            if (!StudentValidator.KiemTraDiem(sv.diemTrungBinh))
            {
                Console.WriteLine("Điểm trung bình phải từ 0 đến 10!");
                return false;
            }

            if (!StudentValidator.KiemTraEmail(sv.email))
            {
                Console.WriteLine("Email không đúng định dạng!");
                return false;
            }

            students.Add(sv);

            Console.WriteLine("Thêm sinh viên thành công!");
            return true;
        }


        // =====================================================
        // 2. HIỂN THỊ DANH SÁCH
        // =====================================================
        public List<Student> LayDanhSach()
        {
            return students;
        }


        // =====================================================
        // 3. TÌM SINH VIÊN THEO MÃ
        // =====================================================
        public Student TimTheoMa(string masv)
        {
            return students.FirstOrDefault(s =>
                s.masv.Equals(
                    masv,
                    StringComparison.OrdinalIgnoreCase));
        }


        // =====================================================
        // 4. TÌM GẦN ĐÚNG THEO HỌ TÊN
        // =====================================================
        public List<Student> TimGanDungTheoHoTen(string hoTen)
        {
            return students
                .Where(s => s.hoTen.Contains(
                    hoTen,
                    StringComparison.OrdinalIgnoreCase))
                .ToList();
        }


        // =====================================================
        // 5. CẬP NHẬT SINH VIÊN
        // =====================================================
        public bool CapNhatSinhVien(string masv, Student svMoi)
        {
            Student svCu = TimTheoMa(masv);

            // Sinh viên không tồn tại
            if (svCu == null)
            {
                Console.WriteLine("Sinh viên không tồn tại!");
                return false;
            }

            // Kiểm tra họ tên
            if (!StudentValidator.KiemTraHoTen(svMoi.hoTen))
            {
                Console.WriteLine("Họ tên không được để trống!");
                return false;
            }

            // Kiểm tra điểm
            if (!StudentValidator.KiemTraDiem(
                svMoi.diemTrungBinh))
            {
                Console.WriteLine(
                    "Điểm trung bình phải từ 0 đến 10!");
                return false;
            }

            // Kiểm tra email
            if (!StudentValidator.KiemTraEmail(svMoi.email))
            {
                Console.WriteLine("Email không đúng định dạng!");
                return false;
            }

            svCu.hoTen = svMoi.hoTen;
            svCu.ngaySinh = svMoi.ngaySinh;
            svCu.gioiTinh = svMoi.gioiTinh;
            svCu.email = svMoi.email;
            svCu.soDienThoai = svMoi.soDienThoai;
            svCu.nganh = svMoi.nganh;
            svCu.diemTrungBinh = svMoi.diemTrungBinh;
            svCu.trangThai = svMoi.trangThai;

            Console.WriteLine("Cập nhật thành công!");
            return true;
        }


        // =====================================================
        // 6. XÓA SINH VIÊN
        // =====================================================
        public bool XoaSinhVien(string masv)
        {
            Student sv = TimTheoMa(masv);

            if (sv == null)
            {
                Console.WriteLine("Sinh viên không tồn tại!");
                return false;
            }

            students.Remove(sv);

            Console.WriteLine("Xóa sinh viên thành công!");
            return true;
        }


        // =====================================================
        // 7. SẮP XẾP THEO HỌ TÊN
        // =====================================================
        public void SapXepTheoHoTen()
        {
            students = students
                .OrderBy(s => s.hoTen)
                .ToList();

            Console.WriteLine("Đã sắp xếp theo họ tên!");
        }


        // =====================================================
        // 8. SẮP XẾP THEO ĐIỂM TRUNG BÌNH
        // =====================================================
        public void SapXepTheoDiem()
        {
            students = students
                .OrderByDescending(s => s.diemTrungBinh)
                .ToList();

            Console.WriteLine(
                "Đã sắp xếp theo điểm trung bình!");
        }


        // =====================================================
        // 9. SINH VIÊN CÓ ĐIỂM TỪ 8 TRỞ LÊN
        // =====================================================
        public List<Student> LaySinhVienDiemTu8()
        {
            return students
                .Where(s => s.diemTrungBinh >= 8)
                .ToList();
        }


        // =====================================================
        // 10. SINH VIÊN CÓ ĐIỂM CAO NHẤT
        // =====================================================
        public List<Student> LaySinhVienDiemCaoNhat()
        {
            if (students.Count == 0)
            {
                return new List<Student>();
            }

            float diemCaoNhat =
                students.Max(s => s.diemTrungBinh);

            return students
                .Where(s => s.diemTrungBinh == diemCaoNhat)
                .ToList();
        }


        // =====================================================
        // 11. TÍNH ĐIỂM TRUNG BÌNH TOÀN BỘ
        // =====================================================
        public float TinhDiemTrungBinh()
        {
            if (students.Count == 0)
            {
                return 0;
            }

            return students.Average(
                s => s.diemTrungBinh);
        }


        // =====================================================
        // 12. THỐNG KÊ SINH VIÊN THEO NGÀNH
        // =====================================================
        public Dictionary<string, int> ThongKeTheoNganh()
        {
            return students
                .GroupBy(s => s.nganh)
                .ToDictionary(
                    g => g.Key,
                    g => g.Count());
        }


        // =====================================================
        // 13. THỐNG KÊ SINH VIÊN THEO TRẠNG THÁI
        // =====================================================
        public Dictionary<string, int> ThongKeTheoTrangThai()
        {
            Dictionary<string, int> ketQua =
                new Dictionary<string, int>();

            ketQua["Đang học"] =
                students.Count(s => s.trangThai);

            ketQua["Đã tốt nghiệp"] =
                students.Count(s => !s.trangThai);

            return ketQua;
        }
    }
}