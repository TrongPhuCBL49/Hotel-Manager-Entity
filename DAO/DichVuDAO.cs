using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO
{
    public class DichVuDAO
    {
        private static DichVuDAO instance;

        public static DichVuDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DichVuDAO();
                return instance;
            }
        }

        private DichVuDAO() { }

        public DataTable DSDichVu()
        {
            SimpleQuanLyKhachSanEntities QLKSEntities = new SimpleQuanLyKhachSanEntities();
            var dstp = from p in QLKSEntities.DichVus
                       select p;
            DataTable dtb = new DataTable();
            dtb.Columns.Add("ID");
            dtb.Columns.Add("Ten");
            dtb.Columns.Add("Gia");
            foreach (var p in dstp)
            {
                dtb.Rows.Add(p.ID, p.Ten, p.Gia);
            }
            return dtb;
        }

        public bool ThemDichVu(DichVu dichVu)
        {
            SimpleQuanLyKhachSanEntities QLKSEntities = new SimpleQuanLyKhachSanEntities();
            QLKSEntities.DichVus.Add(dichVu);
            QLKSEntities.SaveChanges();
            return true;
        }
        public bool SuaDichVu(DichVu dichVu)
        {
            SimpleQuanLyKhachSanEntities QLKSEntities = new SimpleQuanLyKhachSanEntities();
            var Query = (from p in QLKSEntities.DichVus
                         where p.ID == dichVu.ID
                         select p).SingleOrDefault();
            if (Query != null)
            {
                Query.Ten = dichVu.Ten;
                Query.Gia = dichVu.Gia;
                QLKSEntities.SaveChanges();
            }
            return true;
        }
        public bool XoaDichVu(DichVu dichVu)
        {
            SimpleQuanLyKhachSanEntities QLKSEntities = new SimpleQuanLyKhachSanEntities();
            QLKSEntities.DichVus.Attach(dichVu);
            QLKSEntities.DichVus.Remove(dichVu);
            QLKSEntities.SaveChanges();
            return true;

        }
    }
}
