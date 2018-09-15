using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUS;
using DTO;

namespace GUI
{
    public partial class DatPhongGUI : DevExpress.XtraEditors.XtraUserControl
    {
        public DatPhongGUI()
        {
            InitializeComponent();
        }
        void LoadKhachHang()
        {
            DataTable dtbKhachHang = KhachHangBUS.Instance.DSKhachHang();
            foreach (DataRow row in dtbKhachHang.Rows)
                cboKhachHang.Properties.Items.Add(row["Ten"]);
        }
        void LoadPhong()
        {
            DataTable dtbPhong = PhongBUS.Instance.DSPhong();
            foreach (DataRow row in dtbPhong.Rows)
                if (row["TrangThai"].ToString() == "Chưa đặt")
                    cboPhong.Properties.Items.Add(row["Ten"]);
        }

        void BindingThongTinKH()
        {
            KhachHangDTO kh = DatPhongBUS.Instance.ThongTinKhachHang(cboKhachHang.Text);
            txtID.DataBindings.Add("Text", kh, "Id");
            txtTenKhachHang.DataBindings.Add("Text", kh, "Ten");
            txtSDT.DataBindings.Add("Text", kh, "Sdt");
            txtCMND.DataBindings.Add("Text", kh, "Cmnd");
            txtEmail.DataBindings.Add("Text", kh, "Email");
            txtQuocTich.DataBindings.Add("Text", kh, "QuocTich");
            txtGioiTinh.DataBindings.Add("Text", kh, "GioiTinh");
        }
        private void DatPhongGUI_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
            LoadPhong();
            cboKhachHang.SelectedIndex = 0;
            cboPhong.SelectedIndex = 0;
            txtNhanTenPhong.DataBindings.Add("Text", cboPhong, "Text");
            txtTenNhanVienLap.Text = DatPhongBUS.Instance.TenNhanVien(DangNhapGUI.IdNhanVien);
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            if (DatPhongBUS.Instance.ThemBangThuePhong(DangNhapGUI.IdNhanVien, txtID.Text, cboPhong.Text, cboNgayDatPhong.DateTime, cboNgayTraPhong.DateTime, txtTienDatCoc.Text))
            {
                DatPhongBUS.Instance.UpdateTrangThaiPhong(cboPhong.Text);
                MessageBox.Show("Đặt phòng thành công!");
            }
            else
                MessageBox.Show("Có lỗi xảy ra. Đặt phòng thất bại!");
        }

        private void cboKhachHang_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearBinding();
            BindingThongTinKH();
        }
        private void ClearBinding()
        {
            txtID.DataBindings.Clear();
            txtTenKhachHang.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtCMND.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtQuocTich.DataBindings.Clear();
            txtGioiTinh.DataBindings.Clear();
        }
    }
}
