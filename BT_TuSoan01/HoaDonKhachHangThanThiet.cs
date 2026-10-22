using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_TuSoan01
{
    public class HoaDonKhachHangThanThiet : HoaDon, IThanhToanTamUngLaiSuatTraCham
    {
        public HoaDonKhachHangThanThiet(): base() { }

        public HoaDonKhachHangThanThiet(string maHD, string hoTen, DateTime ngayLap, double khoangCach, double khoiLuong, double donGia) : 
            base(maHD, hoTen, ngayLap, khoangCach, khoiLuong, donGia)
        { }

        public override double GiamGia()
        {
            double a = 0.0d;

            if (KhoangCach > 80)
                a = ThanhTien() * 0.06;

            else if (KhoangCach <= 80 && ThanhTien() >= 1500000)
                a = ThanhTien() * 0.04;

            else if (KhoiLuong > 50)
                a = ThanhTien() * 0.02;

            else
                a = 0;

            return a;
        }

        public double ThanhToanTamUng()
        {
            return ThanhToan() * 0.7;
        }

        public double LaiSuatTraCham()
        {
            return (ThanhToan() - ThanhToanTamUng()) * 0.03;
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine();
        }
    }
}
