using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;

namespace BUS
{
    public class DSPhongBUS
    {
        private static DSPhongBUS instance;

        public static DSPhongBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new DSPhongBUS();
                return instance;
            }
        }

        private DSPhongBUS() { }
        public List<PhongDTO> DSPhong()
        {
            List<PhongDTO> dsPhong = new List<PhongDTO>();
            DataTable dtb = DSPhongDAO.Instance.DSPhong();
            foreach (DataRow item in dtb.Rows)
            {
                PhongDTO phong = new PhongDTO();
                phong.Id = item["ID"].ToString();
                phong.Ten = item["Ten"].ToString();
                phong.IdLoai = (int)item["IDLoai"];
                phong.IdTrangThai = (int)item["IDTrangThai"];
                dsPhong.Add(phong);
            }
            return dsPhong;
        }
    }
}