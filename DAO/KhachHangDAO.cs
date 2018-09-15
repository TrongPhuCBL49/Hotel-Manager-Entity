using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO
{
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;

        public static KhachHangDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhachHangDAO();
                return instance;
            }
        }

        private KhachHangDAO() { }

        public DataTable DSKhachHang()
        {
            SimpleQuanLyKhachSanEntities QLKSEntities = new SimpleQuanLyKhachSanEntities();
            var dstp = from p in QLKSEntities.KhachHangs
                       select p;
            DataTable dtb = new DataTable();
            dtb.Columns.Add("ID");
            dtb.Columns.Add("Ten");
            dtb.Columns.Add("NgaySinh");
            dtb.Columns.Add("GioiTinh");
            dtb.Columns.Add("QuocTich");
            dtb.Columns.Add("SDT");
            dtb.Columns.Add("CMND");
            dtb.Columns.Add("Email");

            foreach (var p in dstp)
            {
                dtb.Rows.Add(p.ID, p.Ten, p.NgaySinh, p.GioiTinh, p.QuocTich, p.SDT, p.CMND, p.Email);
            }
            return dtb;
        }

        public bool ThemKhachHang(KhachHang khachHang)
        {
            SimpleQuanLyKhachSanEntities QLKSEntities = new SimpleQuanLyKhachSanEntities();
            QLKSEntities.KhachHangs.Add(khachHang);
            QLKSEntities.SaveChanges();
            return true;
        }
        public bool SuaKhachHang(KhachHang khachHang)
        {
            SimpleQuanLyKhachSanEntities QLKSEntities = new SimpleQuanLyKhachSanEntities();
            var Query = (from p in QLKSEntities.KhachHangs
                         where p.ID == khachHang.ID
                         select p).SingleOrDefault();
            if (Query != null)
            {
                Query.Ten = khachHang.Ten;
                Query.NgaySinh = khachHang.NgaySinh;
                Query.GioiTinh = khachHang.GioiTinh;
                Query.QuocTich = khachHang.QuocTich;
                Query.SDT = khachHang.SDT;
                Query.CMND = khachHang.CMND;
                Query.Email = khachHang.Email;
                QLKSEntities.SaveChanges();
            }
            return true;
        }
        public bool XoaKhachHang(KhachHang khachHang)
        {
            SimpleQuanLyKhachSanEntities QLKSEntities = new SimpleQuanLyKhachSanEntities();
            QLKSEntities.KhachHangs.Attach(khachHang);
            QLKSEntities.KhachHangs.Remove(khachHang);
            QLKSEntities.SaveChanges();
            return true;
        }
    }
}
