using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        private string _id;
        private string _ten;
        private DateTime _ngaySinh;
        private string _gioiTinh;
        private string _diaChi;
        private string _sdt;
        private string _cmnd;
        private string _email;
        private int _idChucDanh;
        public string Id { get => _id; set => _id = value; }
        public string Ten { get => _ten; set => _ten = value; }
        public DateTime NgaySinh { get => _ngaySinh; set => _ngaySinh = value; }
        public string GioiTinh { get => _gioiTinh; set => _gioiTinh = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }
        public string Sdt { get => _sdt; set => _sdt = value; }
        public string Cmnd { get => _cmnd; set => _cmnd = value; }
        public string Email { get => _email; set => _email = value; }
        public int IdChucDanh { get => _idChucDanh; set => _idChucDanh = value; }
    }
}
