using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO
{
    public class DatPhongDAO
    {
        private static DatPhongDAO instance;

        public static DatPhongDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DatPhongDAO();
                return instance;
            }
        }

        private DatPhongDAO() { }
        public DataRow ThongTinKhachHang(string TenKhachHang)
        { 
            string query = "Select * From KhachHang Where Ten = N'" + TenKhachHang + "'";
            DataTable dtb = DataProvider.Instance.getDS(query);
            return dtb.Rows[0];
        }
        public bool ThemBangThuePhong(BangThuePhongDTO bangThuePhong)
        {
            string[] param = { "@IDPhong", "@IDNhanVien", "@IDKhachHang", "@CheckIn", "@CheckOut", "@TienDatCoc", "@TrangThai" };
            object[] values = { bangThuePhong.IdPhong, bangThuePhong.IdNhanVien, bangThuePhong.IdKhachHang, bangThuePhong.CheckIn, bangThuePhong.CheckOut, bangThuePhong.TienDatCoc, bangThuePhong.TrangThai };
            string query = "Insert Into BangThuePhong Values(@IDPhong,@IDNhanVien,@IDKhachHang,convert(date,@CheckIn,105),convert(date,@CheckOut,105),@TienDatCoc,@TrangThai)";
            return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
        }
        public string IdPhong(string tenPhong)
        {
            string query = "Select ID From Phong Where Ten = N'" + tenPhong + "'";
            DataTable dtb = DataProvider.Instance.getDS(query);
            return dtb.Rows[0]["ID"].ToString();
        }
        public string TenNhanVien(string idNhanVien)
        {
            string query = "Select Ten From NhanVien Where ID = N'" + idNhanVien + "'";
            DataTable dtb = DataProvider.Instance.getDS(query);
            return dtb.Rows[0]["Ten"].ToString();
        }

        public bool UpdateTrangThaiPhong(string tenPhong)
        {
            string[] param = { "@Ten", "@IDTrangThai" };
            object[] values = { tenPhong, 2 };
            string query = "Update Phong Set IDTrangThai=@IDTrangThai Where Ten=@Ten";
            return DataProvider.Instance.ExecuteNonQueryPara(query, param, values);
        }

    }
}
