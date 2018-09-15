using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO
{
    public class DSPhongDAO
    {
        private static DSPhongDAO instance;

        public static DSPhongDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DSPhongDAO();
                return instance;
            }
        }

        private DSPhongDAO() { }

        public DataTable DSPhong()
        {
            string query = "Select * From Phong";
            return DataProvider.Instance.getDS(query);
        }
    }
}