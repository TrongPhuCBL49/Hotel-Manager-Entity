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
    public class DichVuBUS
    {
        private static DichVuBUS instance;

        public static DichVuBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new DichVuBUS();
                return instance;
            }
        }

        private DichVuBUS() { }

        public DataTable DSDichVu()
        {
            return DichVuDAO.Instance.DSDichVu();
        }

        public bool ThemDichVu(string TenDichVu, string Gia)
        {
            DichVu dichVu = new DichVu();
            try
            {
                dichVu.Ten = TenDichVu;
                dichVu.Gia = int.Parse(Gia);
            }
            catch (Exception)
            {
                return false;
            }
            return DichVuDAO.Instance.ThemDichVu(dichVu);
        }
        public bool SuaDichVu(string Id, string TenDichVu, string Gia)
        {
            DichVu dichVu = new DichVu();
            try
            {
                dichVu.ID = int.Parse(Id);
                dichVu.Ten = TenDichVu;
                dichVu.Gia = int.Parse(Gia);
            }
            catch (Exception)
            {
                return false;
            }
            return DichVuDAO.Instance.SuaDichVu(dichVu);
        }
        public bool XoaDichVu(string Id)
        {
            DichVu dichVu = new DichVu();
            dichVu.ID = int.Parse(Id);
            return DichVuDAO.Instance.XoaDichVu(dichVu);
        }
    }
}
