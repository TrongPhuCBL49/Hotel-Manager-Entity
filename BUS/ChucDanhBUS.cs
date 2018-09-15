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
    public class ChucDanhBUS
    {
        private static ChucDanhBUS instance;

        public static ChucDanhBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChucDanhBUS();
                return instance;
            }
        }

        private ChucDanhBUS() { }

        public DataTable DSChucDanh()
        {
            return ChucDanhDAO.Instance.DSChucDanh();
        }

        public bool ThemChucDanh(string TenChucDanh)
        {
            ChucDanh chucDanh = new ChucDanh();
            try
            {
                chucDanh.Ten = TenChucDanh;
            }
            catch (Exception)
            {
                return false;
            }
            return ChucDanhDAO.Instance.ThemChucDanh(chucDanh);
        }
        public bool SuaChucDanh(string Id, string TenChucDanh)
        {
            ChucDanh chucDanh = new ChucDanh();
            try
            {
                chucDanh.ID = int.Parse(Id);
                chucDanh.Ten = TenChucDanh;
            }
            catch (Exception)
            {
                return false;
            }
            return ChucDanhDAO.Instance.SuaChucDanh(chucDanh);
        }
        public bool XoaChucDanh(string Id)
        {
            ChucDanh chucDanh = new ChucDanh();
            chucDanh.ID = int.Parse(Id);
            return ChucDanhDAO.Instance.XoaChucDanh(chucDanh);
        }

    }
}
