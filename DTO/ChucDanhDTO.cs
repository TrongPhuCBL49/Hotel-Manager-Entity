using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChucDanhDTO
    {
        private int _id;
        private string _ten;

        public int Id { get => _id; set => _id = value; }
        public string Ten { get => _ten; set => _ten = value; }
    }
}
