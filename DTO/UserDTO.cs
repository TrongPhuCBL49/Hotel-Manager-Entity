using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        private string _id;
        private string _pass;
        private string _idNhanVien;
        private int _idChucDanh;

        public string Id { get => _id; set => _id = value; }
        public string Pass { get => _pass; set => _pass = value; }
        public string IdNhanVien { get => _idNhanVien; set => _idNhanVien = value; }
        public int IdChucDanh { get => _idChucDanh; set => _idChucDanh = value; }
    }
}
