using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhongDTO
    {
        private string _id;
        private string _ten;
        private int _idLoai;
        private int _idTrangThai;

        public string Id { get => _id; set => _id = value; }
        public string Ten { get => _ten; set => _ten = value; }
        public int IdLoai { get => _idLoai; set => _idLoai = value; }
        public int IdTrangThai { get => _idTrangThai; set => _idTrangThai = value; }
    }
}
