using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiPhongDTO
    {
        private int _id;
        private string _ten;
        private int _gia;
        private int _tienPhuThu;
        private int _soGiuong;

        public int Id { get => _id; set => _id = value; }
        public string Ten { get => _ten; set => _ten = value; }
        public int Gia { get => _gia; set => _gia = value; }
        public int TienPhuThu { get => _tienPhuThu; set => _tienPhuThu = value; }
        public int SoGiuong { get => _soGiuong; set => _soGiuong = value; }
    }
}
