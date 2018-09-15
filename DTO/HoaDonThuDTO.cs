using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonThuDTO
    {
        private int _id;
        private string _idNhanVien;
        private string _idKhachHang;
        private DateTime _ngayLap;
        private int _tongTien;

        public int Id { get => _id; set => _id = value; }
        public string IdNhanVien { get => _idNhanVien; set => _idNhanVien = value; }
        public string IdKhachHang { get => _idKhachHang; set => _idKhachHang = value; }
        public DateTime NgayLap { get => _ngayLap; set => _ngayLap = value; }
        public int TongTien { get => _tongTien; set => _tongTien = value; }
    }
}
