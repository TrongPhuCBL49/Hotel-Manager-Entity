using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class DoiMatKhauBUS
    {
        private static DoiMatKhauBUS instance;

        public static DoiMatKhauBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new DoiMatKhauBUS();
                return instance;
            }
        }
        private DoiMatKhauBUS() { }

        public bool KiemTraPass(string idNhanVien, string pass)
        {
            UserDTO user = new UserDTO();
            user.IdNhanVien = idNhanVien;
            user.Pass = pass;
            return DoiMatKhauDAO.Instance.KiemTraPass(user);
        }

        public bool DoiMatKhau(string idNhanVien, string pass)
        {
            UserDTO user = new UserDTO();
            user.IdNhanVien = idNhanVien;
            user.Pass = pass;
            return DoiMatKhauDAO.Instance.DoiMatKhau(user);
        }
    }
}
