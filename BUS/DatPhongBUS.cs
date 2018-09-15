using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;

namespace BUS
{
    public class DatPhongBUS
    {
        private static DatPhongBUS instance;

        public static DatPhongBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new DatPhongBUS();
                return instance;
            }
        }

        private DatPhongBUS() { }

        public KhachHangDTO ThongTinKhachHang(string Ten)
        {
            KhachHangDTO kh = new KhachHangDTO();
            DataRow row = DatPhongDAO.Instance.ThongTinKhachHang(Ten);
            kh.Id = row["ID"].ToString();
            kh.Ten = row["Ten"].ToString();
            //kh.NgaySinh = DateTime.ParseExact(row["NgaySinh"].ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            kh.QuocTich = row["QuocTich"].ToString();
            kh.Sdt = row["SDT"].ToString();
            kh.Cmnd = row["CMND"].ToString();
            kh.Email = row["Email"].ToString();
            kh.GioiTinh = row["GioiTinh"].ToString();
            return kh;
        }

        public bool ThemBangThuePhong(string IDNhanVien, string IDKhachHang, string TenPhong, DateTime CheckIn, DateTime CheckOut, string TienDatCoc)
        {
            BangThuePhongDTO BangThuePhong = new BangThuePhongDTO();
            try
            {
                BangThuePhong.IdNhanVien = IDNhanVien;
                BangThuePhong.IdKhachHang = IDKhachHang;
                BangThuePhong.IdPhong = DatPhongDAO.Instance.IdPhong(TenPhong);
                BangThuePhong.CheckIn = CheckIn;
                BangThuePhong.CheckOut = CheckOut;
                BangThuePhong.TienDatCoc = int.Parse(TienDatCoc);
                BangThuePhong.TrangThai = 0;

            }
            catch (Exception)
            {
                return false;
            }
            return DatPhongDAO.Instance.ThemBangThuePhong(BangThuePhong);
        }

        public void UpdateTrangThaiPhong(string TenPhong)
        {
            DatPhongDAO.Instance.UpdateTrangThaiPhong(TenPhong);
        }

        public string TenNhanVien(string IdNhanVien)
        {
            return DatPhongDAO.Instance.TenNhanVien(IdNhanVien);
        }
    }
}