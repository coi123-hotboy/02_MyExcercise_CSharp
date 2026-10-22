using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_TuSoan01
{
    public class HoaDonDoanhNghiep : HoaDon, IThanhToanTamUngLaiSuatTraCham
    {

        public HoaDonDoanhNghiep() : base() { }

        public HoaDonDoanhNghiep(string maHD, string hoTen, DateTime ngayLap, double khoangCach, double khoiLuong, double donGia) :
            base(maHD, hoTen, ngayLap, khoangCach, khoiLuong, donGia)
        { }

        public override double GiamGia()
        {
            double a = 0.0d;

            if (KhoangCach > 100)
                a = ThanhTien() * 0.08;

            else if (KhoangCach <= 100 && ThanhTien() >= 2000000)
                a = ThanhTien() * 0.05;

            else if (KhoiLuong >= 100)
                a = ThanhTien() * 0.02;

            else
                a = 0;

            return a;
        }

        public double ThanhToanTamUng()
        {
            return ThanhToan() * 0.5;
        }

        public double LaiSuatTraCham()
        {
            return (ThanhToan() - ThanhToanTamUng()) * 0.02;
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine();
        }
    }
}
