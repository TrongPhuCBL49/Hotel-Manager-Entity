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
    public class NhanVienBUS
    {
        private static NhanVienBUS instance;

        public static NhanVienBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhanVienBUS();
                return instance;
            }
        }

        private NhanVienBUS() { }

        public DataTable DSNhanVien()
        {
            return NhanVienDAO.Instance.DSNhanVien();
        }

        public bool ThemNhanVien(string Id, string TenNhanVien, string ChucDanh, DateTime NgaySinh, string GioiTinh, string DiaChi, string SDT, string CMND, string Email)
        {
            NhanVien nhanVien = new NhanVien();
            try
            {
                nhanVien.ID = Id;
                nhanVien.Ten = TenNhanVien;
                nhanVien.IDChucDanh = NhanVienDAO.Instance.IdChucDanh(ChucDanh);
                nhanVien.NgaySinh = NgaySinh;
                nhanVien.GioiTinh = GioiTinh;
                nhanVien.DiaChi = DiaChi;
                nhanVien.SDT = SDT;
                nhanVien.CMND = CMND;
                nhanVien.Email = Email;
            }
            catch (Exception)
            {
                return false;
            }
            return NhanVienDAO.Instance.ThemNhanVien(nhanVien);
        }
        public bool SuaNhanVien(string Id, string TenNhanVien, string ChucDanh, DateTime NgaySinh, string GioiTinh, string DiaChi, string SDT, string CMND, string Email)
        {
            NhanVien nhanVien = new NhanVien();
            try
            {
                nhanVien.ID = Id;
                nhanVien.Ten = TenNhanVien;
                nhanVien.IDChucDanh = NhanVienDAO.Instance.IdChucDanh(ChucDanh);
                nhanVien.NgaySinh = NgaySinh;
                nhanVien.GioiTinh = GioiTinh;
                nhanVien.DiaChi = DiaChi;
                nhanVien.SDT = SDT;
                nhanVien.CMND = CMND;
                nhanVien.Email = Email;
            }
            catch (Exception)
            {
                return false;
            }
            return NhanVienDAO.Instance.SuaNhanVien(nhanVien);
        }
        public bool XoaNhanVien(string Id)
        {
            NhanVien nhanVien = new NhanVien();
            nhanVien.ID = Id;
            return NhanVienDAO.Instance.XoaNhanVien(nhanVien);
        }

    }
}
