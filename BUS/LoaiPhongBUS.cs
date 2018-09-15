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
    public class LoaiPhongBUS
    {
        private static LoaiPhongBUS instance;

        public static LoaiPhongBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoaiPhongBUS();
                return instance;
            }
        }

        private LoaiPhongBUS() { }

        public DataTable DSLoaiPhong()
        {
            return LoaiPhongDAO.Instance.DSLoaiPhong();
        }

        public bool ThemLoaiPhong(string TenLoaiPhong, string SoGiuong, string Gia, string TienPhuThu)
        {
            LoaiPhongDTO loaiPhong = new LoaiPhongDTO();
            try
            {
                loaiPhong.Ten = TenLoaiPhong;
                loaiPhong.SoGiuong = int.Parse(SoGiuong);
                loaiPhong.Gia = int.Parse(Gia);
                loaiPhong.TienPhuThu = int.Parse(TienPhuThu);
            }
            catch (Exception)
            {
                return false;
            }
            return LoaiPhongDAO.Instance.ThemLoaiPhong(loaiPhong);
        }
        public bool SuaLoaiPhong(string Id, string TenLoaiPhong, string SoGiuong, string Gia, string TienPhuThu)
        {
            LoaiPhongDTO loaiPhong = new LoaiPhongDTO();
            try
            {
                loaiPhong.Id = int.Parse(Id);
                loaiPhong.Ten = TenLoaiPhong;
                loaiPhong.SoGiuong = int.Parse(SoGiuong);
                loaiPhong.Gia = int.Parse(Gia);
                loaiPhong.TienPhuThu = int.Parse(TienPhuThu);
            }
            catch (Exception)
            {
                return false;
            }
            return LoaiPhongDAO.Instance.SuaLoaiPhong(loaiPhong);
        }
        public bool XoaLoaiPhong(string Id)
        {
            LoaiPhongDTO loaiPhong = new LoaiPhongDTO();
            loaiPhong.Id = int.Parse(Id);
            return LoaiPhongDAO.Instance.XoaLoaiPhong(loaiPhong);
        }

    }
}
