using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAo.DTO
{
    public class SanPham
    {
        private string maMatHang;
        private string tenMatHang;
        private string maLoai;
        private string maChiTiet;
        private string maThuongHieu;
        private int soLuong;
        private string donViTinh;
        private float donGia;

        public SanPham(string maMatHang, string tenMatHang, string maLoai, string maChiTiet,
                        string maThuongHieu, int soLuong, string donViTinh, float donGia)
        {
            this.MaMatHang = maMatHang;
            this.TenMatHang = tenMatHang;
            this.MaLoai = maLoai;
            this.MaChiTiet = maChiTiet;
            this.MaThuongHieu = maThuongHieu;
            this.SoLuong = soLuong;
            this.DonViTinh = donViTinh;
            this.DonGia = donGia;
        }

        public SanPham(DataRow row)
        {
            this.MaMatHang = row["maMatHang"].ToString();
            this.TenMatHang = row["tenMatHang"].ToString();
            this.MaLoai = row["maLoai"].ToString();
            this.MaChiTiet = row["maChiTiet"].ToString();
            this.MaThuongHieu = row["maThuongHieu"].ToString();
            this.SoLuong = (int)row["soLuong"];
            this.DonViTinh = row["donViTinh"].ToString();
            this.DonGia = (float)row["donGia"];
        }

        public string MaMatHang
        { 
            get => maMatHang; 
            set => maMatHang = value; 
        }
        public string TenMatHang 
        { 
            get => tenMatHang;
            set => tenMatHang = value; 
        }
        public string MaLoai 
        { 
            get => maLoai; 
            set => maLoai = value; 
        }
        public string MaChiTiet {
            get => maChiTiet; 
            set => maChiTiet = value; 
        }
        public string MaThuongHieu 
        { 
            get => maThuongHieu; 
            set => maThuongHieu = value; 
        }
        public int SoLuong 
        { 
            get => soLuong; 
            set => soLuong = value; 
        }
        public string DonViTinh
        { 
            get => donViTinh; 
            set => donViTinh = value; 
        }
        public float DonGia 
        { 
            get => donGia; 
            set => donGia = value; 
        }
    }
}
