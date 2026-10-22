using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_TuSoan01
{
    public abstract class HoaDon
    {
        protected string maHD;
        protected string hoTen;
        protected DateTime ngayLap;
        protected double khoangCach;
        protected double khoiLuong;
        protected double donGia;

        public string MaHD
        {
            get { return maHD; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.StartsWith("HD") && value.Length == 6 && value.Substring(2).All(char.IsDigit))
                    maHD = value;
                else
                    maHD = "HD0001";
            }
        }

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        public DateTime NgayLap
        {
            get { return ngayLap; }
            set { ngayLap = value; }
        }

        public double KhoangCach
        {
            get { return khoangCach; }
            set
            {
                if (value < 0)
                    khoangCach = 0;
                else
                    khoangCach = value;
            }
        }

        public double KhoiLuong
        {
            get { return khoiLuong; }
            set
            {
                if (value < 0)
                    khoiLuong = 0;
                else
                    khoiLuong = value;
            }
        }

        public double DonGia
        {
            get { return donGia; }
            set
            {
                if (value < 0)
                    donGia = 0;
                else
                    donGia = value;
            }
        }

        public HoaDon() { }

        public HoaDon(string maHD, string hoTen, DateTime ngayLap, double khoangCach, double khoiLuong, double donGia)
        {
            MaHD = maHD;
            HoTen = hoTen;
            NgayLap = ngayLap;
            KhoangCach = khoangCach;
            KhoiLuong = khoiLuong;
            DonGia = donGia;
        }

        public double ThanhTien()
        {
            return KhoangCach * DonGia;
        }

        public abstract double GiamGia();

        public double ThanhToan()
        {
            return ThanhTien() - GiamGia();
        }

        public virtual void Xuat()
        {
            Console.WriteLine($"Ma hoa don: {MaHD}");
            Console.WriteLine($"ho ten khach hang: {HoTen}");
            Console.WriteLine($"Ngay lap: {NgayLap:dd/MM/yyyy}");
            Console.WriteLine($"Khoang cach: {KhoangCach}");
            Console.WriteLine($"Khoi luong: {KhoiLuong}");
            Console.WriteLine($"Don gia: {DonGia}");
            Console.WriteLine($"Giam gia: {GiamGia()}");
            Console.WriteLine($"Tong thanh toan: {ThanhToan()}");
        }
    }
}
