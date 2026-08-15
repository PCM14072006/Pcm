using System;
using System.Collections.Generic;

namespace PcmLesson01
{
    internal class MenuManager
    {
        private StudentService service;
        private StudentConsoleView view;

        public MenuManager(StudentService service)
        {
            this.service = service;
            this.view = new StudentConsoleView();
        }

        // Hiển thị menu
        public void HienThiMenu()
        {
            Console.WriteLine();
            Console.WriteLine("========= CHỨC NĂNG =========");
            Console.WriteLine("1. Thêm sinh viên.");
            Console.WriteLine("2. Hiển thị danh sách.");
            Console.WriteLine("3. Tìm sinh viên theo mã.");
            Console.WriteLine("4. Tìm gần đúng theo họ tên.");
            Console.WriteLine("5. Cập nhật sinh viên.");
            Console.WriteLine("6. Xóa sinh viên.");
            Console.WriteLine("7. Sắp xếp theo họ tên.");
            Console.WriteLine("8. Sắp xếp theo điểm trung bình.");
            Console.WriteLine("9. Hiển thị sinh viên có điểm từ 8 trở lên.");
            Console.WriteLine("10. Hiển thị sinh viên có điểm cao nhất.");
            Console.WriteLine("11. Tính điểm trung bình toàn bộ sinh viên.");
            Console.WriteLine("12. Thống kê sinh viên theo ngành.");
            Console.WriteLine("13. Thống kê sinh viên theo trạng thái.");
            Console.WriteLine("14. Thoát");
            Console.WriteLine("=============================");
        }

        // Chạy chương trình
        public void Run()
        {
            string choice;

            do
            {
                HienThiMenu();

                Console.Write("Bạn chọn chức năng: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ChucNang1();
                        break;

                    case "2":
                        ChucNang2();
                        break;

                    case "3":
                        ChucNang3();
                        break;

                    case "4":
                        ChucNang4();
                        break;

                    case "5":
                        ChucNang5();
                        break;

                    case "6":
                        ChucNang6();
                        break;

                    case "7":
                        ChucNang7();
                        break;

                    case "8":
                        ChucNang8();
                        break;

                    case "9":
                        ChucNang9();
                        break;

                    case "10":
                        ChucNang10();
                        break;

                    case "11":
                        ChucNang11();
                        break;

                    case "12":
                        ChucNang12();
                        break;

                    case "13":
                        ChucNang13();
                        break;

                    case "14":
                        Console.WriteLine("Bạn đã thoát chương trình.");
                        break;

                    default:
                        Console.WriteLine("Bạn chọn sai chức năng!");
                        break;
                }

                if (choice != "14")
                {
                    Console.WriteLine();
                    Console.WriteLine("Nhấn Enter để tiếp tục...");
                    Console.ReadLine();
                }

            } while (choice != "14");
        }


        // =====================================================
        // CHỨC NĂNG 1: THÊM SINH VIÊN
        // =====================================================
        private void ChucNang1()
        {
            Console.WriteLine("\n========== THÊM SINH VIÊN ==========");

            List<Student> students = service.LayDanhSach();

            Student sv = view.NhapSinhVien(students);

            service.ThemSinhVien(sv);
        }


        // =====================================================
        // CHỨC NĂNG 2: HIỂN THỊ
        // =====================================================
        private void ChucNang2()
        {
            Console.WriteLine("\n========== DANH SÁCH SINH VIÊN ==========");

            view.HienThiDanhSach(service.LayDanhSach());
        }


        // =====================================================
        // CHỨC NĂNG 3: TÌM THEO MÃ
        // =====================================================
        private void ChucNang3()
        {
            Console.WriteLine("\n========== TÌM SINH VIÊN THEO MÃ ==========");

            Console.Write("Nhập mã sinh viên: ");
            string masv = Console.ReadLine();

            Student sv = service.TimTheoMa(masv);

            if (sv == null)
            {
                Console.WriteLine("Không tìm thấy sinh viên!");
                return;
            }

            view.HienThiSinhVien(sv);
        }


        // =====================================================
        // CHỨC NĂNG 4: TÌM GẦN ĐÚNG THEO TÊN
        // =====================================================
        private void ChucNang4()
        {
            Console.WriteLine("\n========== TÌM GẦN ĐÚNG THEO HỌ TÊN ==========");

            Console.Write("Nhập họ tên cần tìm: ");
            string hoTen = Console.ReadLine();

            List<Student> ketQua =
                service.TimGanDungTheoHoTen(hoTen);

            if (ketQua.Count == 0)
            {
                Console.WriteLine("Không tìm thấy sinh viên!");
                return;
            }

            view.HienThiDanhSach(ketQua);
        }


        // =====================================================
        // CHỨC NĂNG 5: CẬP NHẬT
        // =====================================================
        private void ChucNang5()
        {
            Console.WriteLine("\n========== CẬP NHẬT SINH VIÊN ==========");

            Console.Write("Nhập mã sinh viên cần cập nhật: ");
            string masv = Console.ReadLine();

            Student svCu = service.TimTheoMa(masv);

            if (svCu == null)
            {
                Console.WriteLine("Sinh viên không tồn tại!");
                return;
            }

            Console.WriteLine("Nhập thông tin mới:");

            Student svMoi = view.NhapSinhVien(
                service.LayDanhSach());

            // Giữ lại mã sinh viên cũ
            svMoi.masv = svCu.masv;

            service.CapNhatSinhVien(masv, svMoi);
        }


        // =====================================================
        // CHỨC NĂNG 6: XÓA
        // =====================================================
        private void ChucNang6()
        {
            Console.WriteLine("\n========== XÓA SINH VIÊN ==========");

            Console.Write("Nhập mã sinh viên cần xóa: ");
            string masv = Console.ReadLine();

            Student sv = service.TimTheoMa(masv);

            if (sv == null)
            {
                Console.WriteLine("Sinh viên không tồn tại!");
                return;
            }

            view.HienThiSinhVien(sv);

            Console.Write("Bạn có chắc muốn xóa? (Y/N): ");
            string answer = Console.ReadLine();

            if (answer.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                service.XoaSinhVien(masv);
            }
            else
            {
                Console.WriteLine("Đã hủy xóa.");
            }
        }


        // =====================================================
        // CHỨC NĂNG 7: SẮP XẾP THEO HỌ TÊN
        // =====================================================
        private void ChucNang7()
        {
            Console.WriteLine("\n========== SẮP XẾP THEO HỌ TÊN ==========");

            service.SapXepTheoHoTen();

            view.HienThiDanhSach(service.LayDanhSach());
        }


        // =====================================================
        // CHỨC NĂNG 8: SẮP XẾP THEO ĐIỂM
        // =====================================================
        private void ChucNang8()
        {
            Console.WriteLine("\n========== SẮP XẾP THEO ĐIỂM ==========");

            service.SapXepTheoDiem();

            view.HienThiDanhSach(service.LayDanhSach());
        }


        // =====================================================
        // CHỨC NĂNG 9: ĐIỂM TỪ 8 TRỞ LÊN
        // =====================================================
        private void ChucNang9()
        {
            Console.WriteLine("\n========== SINH VIÊN CÓ ĐIỂM TỪ 8 ==========");

            List<Student> ketQua =
                service.LaySinhVienDiemTu8();

            view.HienThiDanhSach(ketQua);
        }


        // =====================================================
        // CHỨC NĂNG 10: ĐIỂM CAO NHẤT
        // =====================================================
        private void ChucNang10()
        {
            Console.WriteLine("\n========== SINH VIÊN ĐIỂM CAO NHẤT ==========");

            List<Student> ketQua =
                service.LaySinhVienDiemCaoNhat();

            view.HienThiDanhSach(ketQua);
        }


        // =====================================================
        // CHỨC NĂNG 11: ĐIỂM TRUNG BÌNH TOÀN BỘ
        // =====================================================
        private void ChucNang11()
        {
            Console.WriteLine("\n========== ĐIỂM TRUNG BÌNH ==========");

            float diem = service.TinhDiemTrungBinh();

            Console.WriteLine(
                "Điểm trung bình của toàn bộ sinh viên: "
                + diem.ToString("0.00"));
        }


        // =====================================================
        // CHỨC NĂNG 12: THỐNG KÊ THEO NGÀNH
        // =====================================================
        private void ChucNang12()
        {
            Console.WriteLine("\n========== THỐNG KÊ THEO NGÀNH ==========");

            Dictionary<string, int> ketQua =
                service.ThongKeTheoNganh();

            foreach (var item in ketQua)
            {
                Console.WriteLine(
                    item.Key + ": "
                    + item.Value
                    + " sinh viên");
            }
        }


        // =====================================================
        // CHỨC NĂNG 13: THỐNG KÊ THEO TRẠNG THÁI
        // =====================================================
        private void ChucNang13()
        {
            Console.WriteLine("\n========== THỐNG KÊ THEO TRẠNG THÁI ==========");

            Dictionary<string, int> ketQua =
                service.ThongKeTheoTrangThai();

            foreach (var item in ketQua)
            {
                Console.WriteLine(
                    item.Key + ": "
                    + item.Value
                    + " sinh viên");
            }
        }
    }
}