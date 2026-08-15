using System;
using System.Collections.Generic;
using System.Text;

namespace PcmLesson01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // Danh sách sinh viên ban đầu
            List<Student> students = new List<Student>()
            {
                new Student
                {
                    masv = "SV001",
                    hoTen = "Phạm Công Minh",
                    ngaySinh = new DateTime(2006, 7, 14),
                    gioiTinh = true,
                    email = "pcm14072006@gmail.com",
                    soDienThoai = "0333368774",
                    nganh = "Công Nghệ Thông Tin",
                    diemTrungBinh = 8.5f,
                    trangThai = true
                },

                new Student
                {
                    masv = "SV002",
                    hoTen = "Trần Thị Lan Anh",
                    ngaySinh = new DateTime(2005, 5, 20),
                    gioiTinh = false,
                    email = "tranthilananh@gmail.com",
                    soDienThoai = "0987654321",
                    nganh = "Thương mại điện tử",
                    diemTrungBinh = 7.5f,
                    trangThai = true
                },

                new Student
                {
                    masv = "SV003",
                    hoTen = "Lê Văn Cừu",
                    ngaySinh = new DateTime(2004, 10, 10),
                    gioiTinh = true,
                    email = "levancuu@gmail.com",
                    soDienThoai = "0912345678",
                    nganh = "Công nghệ thông tin",
                    diemTrungBinh = 9.0f,
                    trangThai = false
                }
            };

            // Khởi tạo StudentService
            StudentService service = new StudentService(students);

            string choice;

            do
            {
                Menu();

                Console.Write("\nBạn chọn chức năng: ");
                choice = Console.ReadLine();

                Console.Clear();

                switch (choice)
                {
                    // =================================================
                    // 1. THÊM SINH VIÊN
                    // =================================================
                    case "1":
                        {
                            Student sv = NhapSinhVien();
                            service.ThemSinhVien(sv);
                            break;
                        }

                    // =================================================
                    // 2. HIỂN THỊ DANH SÁCH
                    // =================================================
                    case "2":
                        {
                            List<Student> danhSach =
                                service.LayDanhSach();

                            Console.WriteLine("========== DANH SÁCH SINH VIÊN ==========");

                            if (danhSach.Count == 0)
                            {
                                Console.WriteLine("Danh sách sinh viên đang trống.");
                            }
                            else
                            {
                                foreach (Student sv in danhSach)
                                {
                                    HienThiSinhVien(sv);
                                }
                            }

                            break;
                        }

                    // =================================================
                    // 3. TÌM THEO MÃ
                    // =================================================
                    case "3":
                        {
                            Console.Write("Nhập mã sinh viên cần tìm: ");
                            string masv = Console.ReadLine();

                            Student sv = service.TimTheoMa(masv);

                            if (sv == null)
                            {
                                Console.WriteLine("Không tìm thấy sinh viên.");
                            }
                            else
                            {
                                Console.WriteLine("========== SINH VIÊN TÌM THẤY ==========");
                                HienThiSinhVien(sv);
                            }

                            break;
                        }

                    // =================================================
                    // 4. TÌM GẦN ĐÚNG THEO HỌ TÊN
                    // =================================================
                    case "4":
                        {
                            Console.Write("Nhập họ tên cần tìm: ");
                            string hoTen = Console.ReadLine();

                            List<Student> ketQua =
                                service.TimGanDungTheoHoTen(hoTen);

                            if (ketQua.Count == 0)
                            {
                                Console.WriteLine("Không tìm thấy sinh viên.");
                            }
                            else
                            {
                                Console.WriteLine("========== KẾT QUẢ TÌM KIẾM ==========");

                                foreach (Student sv in ketQua)
                                {
                                    HienThiSinhVien(sv);
                                }
                            }

                            break;
                        }

                    // =================================================
                    // 5. CẬP NHẬT
                    // =================================================
                    case "5":
                        {
                            Console.Write("Nhập mã sinh viên cần cập nhật: ");
                            string masv = Console.ReadLine();

                            Student svCu = service.TimTheoMa(masv);

                            if (svCu == null)
                            {
                                Console.WriteLine("Sinh viên không tồn tại.");
                                break;
                            }

                            Console.WriteLine("Nhập thông tin mới:");

                            Student svMoi = NhapSinhVien();

                            // Giữ nguyên mã sinh viên
                            svMoi.masv = masv;

                            service.CapNhatSinhVien(masv, svMoi);

                            break;
                        }

                    // =================================================
                    // 6. XÓA
                    // =================================================
                    case "6":
                        {
                            Console.Write("Nhập mã sinh viên cần xóa: ");
                            string masv = Console.ReadLine();

                            service.XoaSinhVien(masv);

                            break;
                        }

                    // =================================================
                    // 7. SẮP XẾP THEO HỌ TÊN
                    // =================================================
                    case "7":
                        {
                            service.SapXepTheoHoTen();

                            Console.WriteLine("\nDanh sách sau khi sắp xếp:");

                            foreach (Student sv in service.LayDanhSach())
                            {
                                HienThiSinhVien(sv);
                            }

                            break;
                        }

                    // =================================================
                    // 8. SẮP XẾP THEO ĐIỂM
                    // =================================================
                    case "8":
                        {
                            service.SapXepTheoDiem();

                            Console.WriteLine("\nDanh sách sau khi sắp xếp:");

                            foreach (Student sv in service.LayDanhSach())
                            {
                                HienThiSinhVien(sv);
                            }

                            break;
                        }

                    // =================================================
                    // 9. ĐIỂM TỪ 8 TRỞ LÊN
                    // =================================================
                    case "9":
                        {
                            List<Student> ketQua =
                                service.LaySinhVienDiemTu8();

                            Console.WriteLine(
                                "===== SINH VIÊN CÓ ĐIỂM TỪ 8 TRỞ LÊN =====");

                            foreach (Student sv in ketQua)
                            {
                                HienThiSinhVien(sv);
                            }

                            break;
                        }

                    // =================================================
                    // 10. ĐIỂM CAO NHẤT
                    // =================================================
                    case "10":
                        {
                            List<Student> ketQua =
                                service.LaySinhVienDiemCaoNhat();

                            Console.WriteLine(
                                "===== SINH VIÊN CÓ ĐIỂM CAO NHẤT =====");

                            foreach (Student sv in ketQua)
                            {
                                HienThiSinhVien(sv);
                            }

                            break;
                        }

                    // =================================================
                    // 11. ĐIỂM TRUNG BÌNH TOÀN BỘ
                    // =================================================
                    case "11":
                        {
                            float diem =
                                service.TinhDiemTrungBinh();

                            Console.WriteLine(
                                $"Điểm trung bình toàn bộ sinh viên: {diem:F2}");

                            break;
                        }

                    // =================================================
                    // 12. THỐNG KÊ THEO NGÀNH
                    // =================================================
                    case "12":
                        {
                            Dictionary<string, int> ketQua =
                                service.ThongKeTheoNganh();

                            Console.WriteLine("===== THỐNG KÊ THEO NGÀNH =====");

                            foreach (var item in ketQua)
                            {
                                Console.WriteLine(
                                    $"{item.Key}: {item.Value} sinh viên");
                            }

                            break;
                        }

                    // =================================================
                    // 13. THỐNG KÊ THEO TRẠNG THÁI
                    // =================================================
                    case "13":
                        {
                            Dictionary<string, int> ketQua =
                                service.ThongKeTheoTrangThai();

                            Console.WriteLine(
                                "===== THỐNG KÊ THEO TRẠNG THÁI =====");

                            foreach (var item in ketQua)
                            {
                                Console.WriteLine(
                                    $"{item.Key}: {item.Value} sinh viên");
                            }

                            break;
                        }

                    // =================================================
                    // 14. THOÁT
                    // =================================================
                    case "14":
                        {
                            Console.WriteLine("Bạn đã thoát chương trình.");
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Bạn chọn sai chức năng.");
                            break;
                        }
                }

                if (choice != "14")
                {
                    Console.WriteLine("\nNhấn Enter để tiếp tục...");
                    Console.ReadLine();
                    Console.Clear();
                }

            } while (choice != "14");
        }


        // =========================================================
        // MENU
        // =========================================================
        static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("========== CHỨC NĂNG ==========");

            Console.WriteLine("1.  Thêm sinh viên.");
            Console.WriteLine("2.  Hiển thị danh sách.");
            Console.WriteLine("3.  Tìm sinh viên theo mã.");
            Console.WriteLine("4.  Tìm gần đúng theo họ tên.");
            Console.WriteLine("5.  Cập nhật sinh viên.");
            Console.WriteLine("6.  Xóa sinh viên.");
            Console.WriteLine("7.  Sắp xếp theo họ tên.");
            Console.WriteLine("8.  Sắp xếp theo điểm trung bình.");
            Console.WriteLine("9.  Hiển thị sinh viên có điểm từ 8 trở lên.");
            Console.WriteLine("10. Hiển thị sinh viên có điểm cao nhất.");
            Console.WriteLine("11. Tính điểm trung bình toàn bộ sinh viên.");
            Console.WriteLine("12. Thống kê sinh viên theo ngành.");
            Console.WriteLine("13. Thống kê sinh viên theo trạng thái.");
            Console.WriteLine("14. Thoát");

            Console.WriteLine("===============================");
        }


        // =========================================================
        // NHẬP SINH VIÊN
        // =========================================================
        static Student NhapSinhVien()
        {
            Student sv = new Student();

            Console.Write("Mã sinh viên: ");
            sv.masv = Console.ReadLine();

            Console.Write("Họ và tên: ");
            sv.hoTen = Console.ReadLine();

            Console.Write("Ngày sinh (dd/MM/yyyy): ");
            DateTime ngaySinh;

            while (!DateTime.TryParse(Console.ReadLine(), out ngaySinh))
            {
                Console.Write("Ngày sinh không hợp lệ, nhập lại: ");
            }

            sv.ngaySinh = ngaySinh;

            Console.Write("Giới tính (Nam/Nữ): ");
            string gioiTinh = Console.ReadLine();

            sv.gioiTinh =
                gioiTinh.Equals("Nam", StringComparison.OrdinalIgnoreCase);

            Console.Write("Email: ");
            sv.email = Console.ReadLine();

            Console.Write("Số điện thoại: ");
            sv.soDienThoai = Console.ReadLine();

            Console.Write("Ngành: ");
            sv.nganh = Console.ReadLine();

            Console.Write("Điểm trung bình: ");
            float diem;

            while (!float.TryParse(Console.ReadLine(), out diem))
            {
                Console.Write("Điểm không hợp lệ, nhập lại: ");
            }

            sv.diemTrungBinh = diem;

            Console.Write("Trạng thái (Đang học/Đã tốt nghiệp): ");
            string trangThai = Console.ReadLine();

            sv.trangThai =
                trangThai.Equals(
                    "Đang học",
                    StringComparison.OrdinalIgnoreCase);

            return sv;
        }


        // =========================================================
        // HIỂN THỊ 1 SINH VIÊN
        // =========================================================
        static void HienThiSinhVien(Student sv)
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Mã sinh viên:     {sv.masv}");
            Console.WriteLine($"Họ và tên:        {sv.hoTen}");
            Console.WriteLine($"Ngày sinh:        {sv.ngaySinh:dd/MM/yyyy}");
            Console.WriteLine($"Giới tính:        {(sv.gioiTinh ? "Nam" : "Nữ")}");
            Console.WriteLine($"Email:            {sv.email}");
            Console.WriteLine($"Số điện thoại:    {sv.soDienThoai}");
            Console.WriteLine($"Ngành:            {sv.nganh}");
            Console.WriteLine($"Điểm trung bình:  {sv.diemTrungBinh}");
            Console.WriteLine(
                $"Trạng thái:       {(sv.trangThai ? "Đang học" : "Đã tốt nghiệp")}");
            Console.WriteLine("------------------------------------------");
        }
    }
}