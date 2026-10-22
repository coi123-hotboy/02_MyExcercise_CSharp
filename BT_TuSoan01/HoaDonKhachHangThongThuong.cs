using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_TuSoan01
{
    public class HoaDonKhachHangThongThuong : HoaDon
    {
        public HoaDonKhachHangThongThuong() : base() { }

        public HoaDonKhachHangThongThuong(string maHD, string hoTen, DateTime ngayLap, double khoangCach, double khoiLuong, double donGia) :
            base(maHD, hoTen, ngayLap, khoangCach, khoiLuong, donGia) { }

        public override double GiamGia()
        {
            double a = 0.0d;

            if (ThanhTien() > 3000000)
                a = ThanhTien() * 0.03;

            return a;
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine();
        }
    }
}
