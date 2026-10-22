using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_TuSoan01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manage hd = new Manage();

            int choice;

            do
            {
                Console.WriteLine("*=============================================================*");
                Console.WriteLine("|                                                             |");
                Console.WriteLine("|                  QUAN LY DANH SACH HOA DON                  |");
                Console.WriteLine("|                                                             |");
                Console.WriteLine("*=============================================================*");
                Console.WriteLine("|  1. Doc file danh sach hoa don                              |");
                Console.WriteLine("|  2. Xuat danh sach hoa don                                  |");
                Console.WriteLine("|  3. Xuat hoa don cua khach hang thong thuong                |");
                Console.WriteLine("|  4. Tinh tong thanh toan tat ca hoa don                     |");
                Console.WriteLine("|  5. Xuat hoa don co tong thanh toan cao nhat                |");
                Console.WriteLine("|  6. Dem hoa don doanh nghiep va khach hang than thiet       |");
                Console.WriteLine("|  7. Tinh tong tien tam ung cua Nguyen Van An                |");
                Console.WriteLine("|  8. Tinh tong lai suat tra cham cua cac hoa don             |");
                Console.WriteLine("|  9. Sap xep hoa don theo tong thanh toan va ma hoa don      |");
                Console.WriteLine("| 10. Tim khach hang co tong thanh toan cao nhat              |");
                Console.WriteLine("| 11. Tinh doanh thu rieng cua tung loai hoa don              |");
                Console.WriteLine("|  0. Thoat chuong trinh                                      |");
                Console.WriteLine("|                                                             |");
                Console.WriteLine("*=============================================================*");
                Console.Write("Moi ban lua chon: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {

                    case 1:
                        Console.WriteLine();
                        hd.DocFileXML("C:\\C# Basic\\Bài tập THOOP\\BT_TuSoan01\\BT_TuSoan01\\HoaDon.xml");
                        Console.WriteLine("Doc file thanh cong!");
                        Console.WriteLine();
                        break;

                    case 2:
                        Console.WriteLine();
                        hd.XuatHoaDon();
                        break;

                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("--- Hoa don khach hang thong thuong ---");
                        hd.XuatHD_KhachThongThuong();
                        Console.WriteLine();
                        break;

                    case 4:
                        Console.WriteLine();
                        double tongthanhtoan = hd.TongThanhToan();
                        Console.WriteLine($"Tong thanh toan cua tat ca hoa don: {tongthanhtoan} vnd");
                        Console.WriteLine();
                        break;

                    case 5:
                        Console.WriteLine();
                        Console.WriteLine("--- Hoa don co tong thanh toan cao nhat ---");
                        hd.XuatHD_TongThanhToanCaoNhat();
                        Console.WriteLine();
                        break;

                    case 6:
                        Console.WriteLine();
                        int count = hd.CountHD_DoanhNghiepAndThanThiet();
                        Console.WriteLine($"So hoa don cua khach hang doanh nghiep va khach hang than thiet: {count}");
                        Console.WriteLine();
                        break;

                    case 7:
                        Console.WriteLine();

                        double sum = hd.TinhThanhToanTamUng_NguyenVanAn();
                        if (sum == 0)
                            Console.WriteLine("Khong co khach hang 'Nguyen Van An' trong danh sach hoa don");
                        else
                            Console.WriteLine($"Tong thanh toan tam ung cac hoa don cua khach hang 'Nguyen Van An': {sum} vnd");

                        Console.WriteLine();
                        break;

                    case 8:
                        Console.WriteLine();
                        double tonglaisuat = hd.TongLaiSuatTraCham();
                        Console.WriteLine($"Tong lai suat tra cham cua cac hoa don la: {tonglaisuat} vnd");
                        Console.WriteLine();
                        break;


                    case 9:
                        Console.WriteLine();
                        hd.SapXepTangDan();
                        Console.WriteLine();
                        break;

                    case 10:
                        Console.WriteLine();
                        HoaDon hdMax = hd.TimKhachHang_ThanhToanCaoNhat();
                        Console.WriteLine($"Khach hang co thanh toan cao nhat trong danh sach hoa don la: {hdMax.HoTen}");
                        Console.WriteLine();
                        break;

                    case 11:
                        Console.WriteLine();
                        hd.TongDoanhThuTungHoaDon();
                        Console.WriteLine();
                        break;

                    case 0:
                        Console.WriteLine();
                        Console.WriteLine("Cam mon ban da su dung chuong trinh");
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Error");
                        Console.WriteLine();
                        break;
                }

            } while (choice != 0);
        }
    }
}
