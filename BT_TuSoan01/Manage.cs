using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Globalization;

namespace BT_TuSoan01
{
    public class Manage
    {
        List<HoaDon> listHD;

        public List<HoaDon> ListHD
        {
            get { return listHD; }
            set { listHD = value; }
        }

        public Manage()
        {
            ListHD = new List<HoaDon>();
        }

        public Manage(List<HoaDon> ds)
        {
            ListHD = ds;
        }

        public void DocFileXML(string tenFile)
        {
            XmlDocument read = new XmlDocument();

            read.Load(tenFile);

            XmlNodeList nodelist = read.SelectNodes("/DSHD/HoaDon");

            foreach (XmlNode node in nodelist)
            {
                HoaDon hd = null;

                int loai = int.Parse(node["Loai"].InnerText);
                string maHD = node["MaHD"].InnerText;
                string hoTen = node["HoTen"].InnerText;
                DateTime ngayLap = DateTime.ParseExact(node["NgayLap"].InnerText, "d/M/yyyy", CultureInfo.InvariantCulture);
                double khoangCach = double.Parse(node["KhoangCach"].InnerText);
                double khoiLuong = double.Parse(node["KhoiLuong"].InnerText);
                double donGia = double.Parse(node["DonGia"].InnerText);

                if (loai == 1)
                    hd = new HoaDonDoanhNghiep(maHD, hoTen, ngayLap, khoangCach, khoiLuong, donGia);

                else if (loai == 2)
                    hd = new HoaDonKhachHangThanThiet(maHD, hoTen, ngayLap, khoangCach, khoiLuong, donGia);

                else if (loai == 3)
                    hd = new HoaDonKhachHangThongThuong(maHD, hoTen, ngayLap, khoangCach, khoiLuong, donGia);

                else
                    continue;

                ListHD.Add(hd);
            }
        }

        public void XuatHoaDon()
        {
            foreach (HoaDon hd in ListHD)
            {
                hd.Xuat();
            }
        }

        public void XuatHD_KhachThongThuong()
        {
            foreach (HoaDon hd in ListHD)
            {
                if (hd is HoaDonKhachHangThongThuong)
                    hd.Xuat();
            }
        }

        public double TongThanhToan()
        {
            double tt = 0.0d;

            foreach (HoaDon hd in ListHD)
            {
                tt += hd.ThanhToan();    
            }

            return tt;
        }

        public void XuatHD_TongThanhToanCaoNhat()
        {
            double max = -1;
            HoaDon hdMax = null;

            foreach (HoaDon hd in ListHD)
            {
                if(hd.ThanhToan() > max)
                {
                    max = hd.ThanhToan();
                    hdMax = hd;
                }
            }

            if (hdMax != null)
                hdMax.Xuat();
        }

        public int CountHD_DoanhNghiepAndThanThiet()
        {
            int count = 0;

            foreach (HoaDon hd in ListHD)
            {
                if (hd is HoaDonDoanhNghiep || hd is HoaDonKhachHangThanThiet)
                    count++;
            }

            return count;
        }

        public double TinhThanhToanTamUng_NguyenVanAn()
        {
            double tong = 0.0d;

            foreach (HoaDon hd in ListHD)
            {
                if(hd is HoaDonDoanhNghiep hddn)
                {
                    if (string.Equals("nguyen van an", hd.HoTen, StringComparison.OrdinalIgnoreCase))
                        tong += hddn.ThanhToanTamUng();
                }

                else if(hd is HoaDonKhachHangThanThiet hdtt)
                {
                    if (string.Equals("nguyen van an", hd.HoTen, StringComparison.OrdinalIgnoreCase))
                        tong += hdtt.ThanhToanTamUng();
                }
            }

            return tong;
        }

        public double TongLaiSuatTraCham()
        {
            double tong = 0.0d;

            foreach (HoaDon hd in ListHD)
            {
                if (hd is HoaDonDoanhNghiep hddn)
                    tong += hddn.LaiSuatTraCham();

                else if (hd is HoaDonKhachHangThanThiet hdtt)
                    tong += hdtt.LaiSuatTraCham();
            }

            return tong;
        }

        public void SapXepTangDan()
        {
            List<HoaDon> dsMoi = new List<HoaDon>(ListHD);

            for (int i = 0; i < dsMoi.Count - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < dsMoi.Count; j++)
                {
                    if (dsMoi[j].ThanhToan() < dsMoi[min].ThanhToan())
                        min = j;

                    else if(dsMoi[j].ThanhToan() == dsMoi[min].ThanhToan())
                    {
                        if (string.Compare(dsMoi[j].MaHD, dsMoi[min].MaHD) > 0)
                            min = j;
                    }
                }

                if(min != i)
                {
                    HoaDon temp = dsMoi[min];
                    dsMoi[min] = dsMoi[i];
                    dsMoi[i] = temp;
                }
            }

            foreach (HoaDon hd in dsMoi)
            {
                hd.Xuat();
            }
        }

        public HoaDon TimKhachHang_ThanhToanCaoNhat()
        {
            double max = -1;
            HoaDon hdMax = null;

            for (int i = 0; i < ListHD.Count; i++)
            {
                double tong = 0.0d;

                for (int j = 0; j < ListHD.Count; j++)
                {
                    if (ListHD[i].HoTen == ListHD[j].HoTen)
                    {
                        tong += ListHD[j].ThanhToan();
                    }
                }

                if(tong > max)
                {
                    max = tong;
                    hdMax = ListHD[i];
                }
            }

            if (hdMax != null)
                return hdMax;

            return null;
        }

        public void TongDoanhThuTungHoaDon()
        {
            double sumLoai1 = 0.0d;
            double sumLoai2 = 0.0d;
            double sumLoai3 = 0.0d;

            foreach (HoaDon hd in ListHD)
            {
                if (hd is HoaDonDoanhNghiep)
                    sumLoai1 += hd.ThanhToan();

                else if (hd is HoaDonKhachHangThanThiet)
                    sumLoai2 += hd.ThanhToan();

                else if (hd is HoaDonKhachHangThongThuong)
                    sumLoai3 += hd.ThanhToan();

                else
                    continue;
            }

            Console.WriteLine($"Tong doanh thu hoa don doanh nghiep: {sumLoai1} vnd");
            Console.WriteLine($"Tong doanh thu hoa don khach than thiet: {sumLoai2} vnd");
            Console.WriteLine($"Tong doanh thu hoa don khach thong thuong: {sumLoai3} vnd");
        }
    }
}
