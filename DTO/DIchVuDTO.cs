using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DichVuDTO
    {
        private int _id;
        private string _ten;
        private int _gia;

        public int Id { get => _id; set => _id = value; }
        public string Ten { get => _ten; set => _ten = value; }
        public int Gia { get => _gia; set => _gia = value; }
    }
}
