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
    public class PhongBUS
    {
        private static PhongBUS instance;

        public static PhongBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhongBUS();
                return instance;
            }
        }

        private PhongBUS() { }

        public DataTable DSPhong()
        {
            return PhongDAO.Instance.DSPhong();
        }

        public bool ThemPhong(string Id, string TenPhong, string LoaiPhong, string TrangThai)
        {
            PhongDTO phong = new PhongDTO();
            try
            {
                phong.Id = Id;
                phong.Ten = TenPhong;
                phong.IdLoai = PhongDAO.Instance.IdLoaiPhong(LoaiPhong);
                phong.IdTrangThai = PhongDAO.Instance.IdTrangThai(TrangThai);
            }
            catch (Exception)
            {
                return false;
            }
            return PhongDAO.Instance.ThemPhong(phong);
        }
        public bool SuaPhong(string Id, string TenPhong, string LoaiPhong, string TrangThai)
        {
            PhongDTO phong = new PhongDTO();
            try
            {
                phong.Id = Id;
                phong.Ten = TenPhong;
                phong.IdLoai = PhongDAO.Instance.IdLoaiPhong(LoaiPhong);
                phong.IdTrangThai = PhongDAO.Instance.IdTrangThai(TrangThai);
            }
            catch (Exception)
            {
                return false;
            }
            return PhongDAO.Instance.SuaPhong(phong);
        }
        public bool XoaPhong(string Id)
        {
            PhongDTO phong = new PhongDTO();
            phong.Id = Id;
            return PhongDAO.Instance.XoaPhong(phong);
        }
        
    }
}
