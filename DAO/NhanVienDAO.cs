using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO instance;
        public static NhanVienDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhanVienDAO();
                return instance;
            }
        }

        private NhanVienDAO() { }


        public DataTable DSNhanVien()
        {
            SimpleQuanLyKhachSanEntities QLKSEntities = new SimpleQuanLyKhachSanEntities();
            var dstp = from p in QLKSEntities.NhanViens
                       select p;
            DataTable dtb = new DataTable();
            dtb.Columns.Add("ID");
            dtb.Columns.Add("Ten");
            dtb.Columns.Add("ChucDanh");
            dtb.Columns.Add("NgaySinh");
            dtb.Columns.Add("GioiTinh");
            dtb.Columns.Add("DiaChi");
            dtb.Columns.Add("SDT");
            dtb.Columns.Add("CMND");
            dtb.Columns.Add("Email");

            foreach (var p in dstp)
            {
                dtb.Rows.Add(p.ID, p.Ten, p.ChucDanh.Ten, p.NgaySinh, p.GioiTinh, p.DiaChi, p.SDT, p.CMND, p.Email);
            }
            return dtb;
        }

        public bool ThemNhanVien(NhanVien nhanVien)
        {
            SimpleQuanLyKhachSanEntities QLKSEntities = new SimpleQuanLyKhachSanEntities();
            QLKSEntities.NhanViens.Add(nhanVien);
            QLKSEntities.SaveChanges();
            return true;
        }
        public bool SuaNhanVien(NhanVien nhanVien)
        {
            SimpleQuanLyKhachSanEntities QLKSEntities = new SimpleQuanLyKhachSanEntities();
            var Query = (from p in QLKSEntities.NhanViens
                         where p.ID == nhanVien.ID
                         select p).SingleOrDefault();
            if (Query != null)
            {
                Query.Ten = nhanVien.Ten;
                Query.IDChucDanh = nhanVien.IDChucDanh;
                Query.NgaySinh = nhanVien.NgaySinh;
                Query.GioiTinh = nhanVien.GioiTinh;
                Query.DiaChi = nhanVien.DiaChi;
                Query.SDT = nhanVien.SDT;
                Query.CMND = nhanVien.CMND;
                Query.Email = nhanVien.Email;
                QLKSEntities.SaveChanges();
            }
            return true;
        }
        public bool XoaNhanVien(NhanVien nhanVien)
        {
            SimpleQuanLyKhachSanEntities QLKSEntities = new SimpleQuanLyKhachSanEntities();
            QLKSEntities.NhanViens.Attach(nhanVien);
            QLKSEntities.NhanViens.Remove(nhanVien);
            QLKSEntities.SaveChanges();
            return true;
        }
        public int IdChucDanh(string chucDanh)
        {
            SimpleQuanLyKhachSanEntities QLKSEntities = new SimpleQuanLyKhachSanEntities();
            var query = (from p in QLKSEntities.ChucDanhs
                         where p.Ten == chucDanh
                         select p).SingleOrDefault();
            return query.ID;
        }
    }
}
