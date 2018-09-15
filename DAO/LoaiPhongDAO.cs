using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO
{
    public class LoaiPhongDAO
    {
        private static LoaiPhongDAO instance;

        public static LoaiPhongDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoaiPhongDAO();
                return instance;
            }
        }

        private LoaiPhongDAO() { }

        public DataTable DSLoaiPhong()
        {
            string query = "Select * From LoaiPhong";
            return DataProvider.Instance.getDS(query);
        }

        public bool ThemLoaiPhong(LoaiPhongDTO loaiPhong)
        {
            string[] param = { "@Ten", "@Gia", "@TienPhuThu", "@SoGiuong" };
            object[] values = { loaiPhong.Ten, loaiPhong.Gia, loaiPhong.TienPhuThu, loaiPhong.SoGiuong };
            string query = "Insert Into LoaiPhong Values(@Ten,@Gia,@TienPhuThu,@SoGiuong)";
            return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
        }
        public bool SuaLoaiPhong(LoaiPhongDTO loaiPhong)
        {
            string[] param = { "@ID", "@Ten", "@Gia", "@TienPhuThu", "@SoGiuong" };
            object[] values = { loaiPhong.Id, loaiPhong.Ten, loaiPhong.Gia, loaiPhong.TienPhuThu, loaiPhong.SoGiuong };
            string query = "Update LoaiPhong Set Ten=@Ten, Gia=@Gia, TienPhuThu=@TienPhuThu, SoGiuong=@SoGiuong Where ID=@ID";
            return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
        }
        public bool XoaLoaiPhong(LoaiPhongDTO loaiPhong)
        {
            string[] param = { "@ID" };
            object[] values = { loaiPhong.Id };
            string query = "Delete LoaiPhong Where ID=@ID";
            return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
        }
    }
}
