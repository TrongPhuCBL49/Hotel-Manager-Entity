using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return instance;
            } 
        }

        SqlConnection con;
        SqlDataAdapter dap;
        SqlCommand cmd;

        private DataProvider()
        {
            connectDB();
        }

        //Kết nối
        public void connectDB()
        {
            string strCon = "Data Source=DESKTOP-G5TUN54;" +
                            "Initial Catalog=SimpleQuanLyKhachSan;" +
                            "Integrated Security=True";
            con = new SqlConnection(strCon);
            cmd = con.CreateCommand();
            try
            {
                con.Open();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                con.Dispose();
            }
        }

        //Thực hiện câu lệnh sql trả về bảng dữ liệu
        public DataTable getDS(string sql)
        {
            DataTable tbl = new DataTable();
            dap = new SqlDataAdapter(sql, con);
            dap.Fill(tbl);
            return tbl;
        }
        public object ExecuteScalar(string strSQL, CommandType ct)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            cmd.CommandText = strSQL;
            cmd.CommandType = ct;
            object Data = cmd.ExecuteScalar();
            return Data;
        }

        //Thực thi lệnh sql chèn, xóa, sửa
        public bool ExecuteNonQueryPara(string sql, string[] parameters, object[] value)
        {
            int num = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                cmd = new SqlCommand(sql, con);
                SqlParameter p;
                for (int i = 0; i < parameters.Length; i++)
                {
                    p = new SqlParameter(parameters[i], value[i]);
                    cmd.Parameters.Add(p);
                }
                num = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            if (num > 0)
                return true;
            else
                return false;
        }

        public bool ExecuteQuery(string sql)
        {
            int num = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                cmd = new SqlCommand(sql, con);
                num = (int)cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            if (num > 0)
                return true;
            else
                return false;
        }

        //Kiểm tra sự tồn tại
        public bool checkExist(string tblName, string field, string value)
        {
            string sql = "Select Count (*) From " + tblName + " where " + field + "='" + value + "'";
            cmd = new SqlCommand(sql, con);
            int num = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                num = (int)cmd.ExecuteScalar();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            if (num > 0)
                return true;
            else
                return false;
        }

        // Lấy mã cuối cùng
        public string GetLastID(string nameTable, string nameFiled)
        {
            string sql = "SELECT TOP (1) " + nameFiled + " FROM " + nameTable + " ORDER BY " + nameFiled + " DESC";
            return getDS(sql).Rows[0][nameFiled].ToString();
        }
    }
}
