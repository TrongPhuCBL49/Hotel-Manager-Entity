using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO
{
    public class DoiMatKhauDAO
    {
        private static DoiMatKhauDAO instance;
        public static DoiMatKhauDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DoiMatKhauDAO();
                return instance;
            }
        }
        private DoiMatKhauDAO() { }

        public bool KiemTraPass(UserDTO user)
        {
            string query = "Select * From Users Where IDNhanVien = '" + user.IdNhanVien + "' and Pass = '" + user.Pass + "'";
            DataTable dtb = DataProvider.Instance.getDS(query);
            return (dtb.Rows.Count > 0);
        }

        public bool DoiMatKhau(UserDTO user)
        {
            string[] param = { "@IDNhanVien", "@Pass"};
            object[] values = { user.IdNhanVien, user.Pass };
            string query = "Update Users Set Pass=@Pass Where IDNhanVien=@IDNhanVien";
            return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
        }
    }
}
