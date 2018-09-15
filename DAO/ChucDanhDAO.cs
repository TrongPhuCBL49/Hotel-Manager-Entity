using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO
{
    public class ChucDanhDAO
    {
        private static ChucDanhDAO instance;

        public static ChucDanhDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChucDanhDAO();
                return instance;
            }
        }

        private ChucDanhDAO() { }

        public DataTable DSChucDanh()
        {
            SimpleQuanLyKhachSanEntities QLKSEntities = new SimpleQuanLyKhachSanEntities();
            var dstp = from p in QLKSEntities.ChucDanhs
                        select p;
            DataTable dtb = new DataTable();
            dtb.Columns.Add("ID");
            dtb.Columns.Add("Ten");
            foreach (var p in dstp)
            {
                dtb.Rows.Add(p.ID, p.Ten);
            }
            return dtb;
        }

        public bool ThemChucDanh(ChucDanh chucDanh)
        {
            SimpleQuanLyKhachSanEntities QLKSEntities = new SimpleQuanLyKhachSanEntities();
            QLKSEntities.ChucDanhs.Add(chucDanh);
            QLKSEntities.SaveChanges();
            return true;
        }
        public bool SuaChucDanh(ChucDanh chucDanh)
        {
            SimpleQuanLyKhachSanEntities QLKSEntities = new SimpleQuanLyKhachSanEntities();
            var Query = (from p in QLKSEntities.ChucDanhs
                         where p.ID == chucDanh.ID
                         select p).SingleOrDefault();
            if (Query != null)
            {
                Query.Ten = chucDanh.Ten;
                QLKSEntities.SaveChanges();
            }
            return true;
        }
        public bool XoaChucDanh(ChucDanh chucDanh)
        {
            SimpleQuanLyKhachSanEntities QLKSEntities = new SimpleQuanLyKhachSanEntities();
            QLKSEntities.ChucDanhs.Attach(chucDanh);
            QLKSEntities.ChucDanhs.Remove(chucDanh);
            QLKSEntities.SaveChanges();
            return true;

        }
    }
}
