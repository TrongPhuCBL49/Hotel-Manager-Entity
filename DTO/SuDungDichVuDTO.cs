using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SuDungDichVuDTO
    {
        private int _idBangThuePhong;
        private int _idDichVu;

        public int IdBangThuePhong { get => _idBangThuePhong; set => _idBangThuePhong = value; }
        public int IdDichVu { get => _idDichVu; set => _idDichVu = value; }
    }
}
