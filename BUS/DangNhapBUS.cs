using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Data;

namespace BUS
{
    public class DangNhapBUS
    {
        private static DangNhapBUS instance;
        public static DangNhapBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new DangNhapBUS();
                return instance;
            }
        }

        public bool KiemTraUser(string idNhanVien, string pass)
        {
            UserDTO user = new UserDTO();
            user.IdNhanVien = idNhanVien;
            user.Pass = pass;
            return DangNhapDAO.Instance.KiemTraUser(user);
        }

        public int IdChucDanh(string idNhanVien)
        {
            return DangNhapDAO.Instance.IdChucDanh(idNhanVien);
        }
    }
}
