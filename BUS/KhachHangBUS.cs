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
    public class KhachHangBUS
    {
        private static KhachHangBUS instance;

        public static KhachHangBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhachHangBUS();
                return instance;
            }
        }

        private KhachHangBUS() { }

        public DataTable DSKhachHang()
        {
            return KhachHangDAO.Instance.DSKhachHang();
        }

        public bool ThemKhachHang(string Id, string TenKhachHang, DateTime NgaySinh, string GioiTinh, string QuocTich, string SDT, string CMND, string Email)
        {
            KhachHang khachHang = new KhachHang();
            try
            {
                khachHang.ID = Id;
                khachHang.Ten = TenKhachHang;
                khachHang.NgaySinh = NgaySinh;
                khachHang.GioiTinh = GioiTinh;
                khachHang.QuocTich = QuocTich;
                khachHang.SDT = SDT;
                khachHang.CMND = CMND;
                khachHang.Email = Email;
            }
            catch (Exception)
            {
                return false;
            }
            return KhachHangDAO.Instance.ThemKhachHang(khachHang);
        }
        public bool SuaKhachHang(string Id, string TenKhachHang, DateTime NgaySinh, string GioiTinh, string QuocTich, string SDT, string CMND, string Email)
        {
            KhachHang khachHang = new KhachHang();
            try
            {
                khachHang.ID = Id;
                khachHang.Ten = TenKhachHang;
                khachHang.NgaySinh = NgaySinh;
                khachHang.GioiTinh = GioiTinh;
                khachHang.QuocTich = QuocTich;
                khachHang.SDT = SDT;
                khachHang.CMND = CMND;
                khachHang.Email = Email;
            }
            catch (Exception)
            {
                return false;
            }
            return KhachHangDAO.Instance.SuaKhachHang(khachHang);
        }
        public bool XoaKhachHang(string Id)
        {
            KhachHang khachHang = new KhachHang();
            khachHang.ID = Id;
            return KhachHangDAO.Instance.XoaKhachHang(khachHang);
        }

    }
}
