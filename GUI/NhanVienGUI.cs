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
using DevExpress.XtraEditors.Mask;

namespace GUI
{
    public partial class NhanVienGUI : DevExpress.XtraEditors.XtraUserControl
    {
        bool isThem = false;
        public NhanVienGUI()
        {
            InitializeComponent();
        }

        private void NhanVienGUI_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            LoadChucDanh();
            LoadGioiTinh();
        }
        void LoadNhanVien()
        {
            dgvNhanVien.DataSource = NhanVienBUS.Instance.DSNhanVien();
            BindingNhanVien();
            isThem = false;
            txtID.Enabled = false;
            btnHuyBo.Enabled = false;
            btnLuu.Enabled = false;
        }
        void LoadChucDanh()
        {
            DataTable dtbChucDanh = ChucDanhBUS.Instance.DSChucDanh();
            foreach (DataRow row in dtbChucDanh.Rows)
                cboChucDanh.Properties.Items.Add(row["Ten"]);
        }
        void LoadGioiTinh()
        {
            List<string> TrangThai = new List<string>();
            TrangThai.Add("Nam");
            TrangThai.Add("Nữ");
            TrangThai.Add("Khác");
            cboGioiTinh.Properties.Items.AddRange(TrangThai);
        }
        public void BindingNhanVien()
        {
            BindingSource source = new BindingSource();
            source.DataSource = NhanVienBUS.Instance.DSNhanVien();
            source.DataSource = dgvNhanVien.DataSource;
            txtID.DataBindings.Add("Text", source, "ID", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenNhanVien.DataBindings.Add("Text", source, "Ten", true, DataSourceUpdateMode.OnPropertyChanged);
            cboChucDanh.DataBindings.Add("Text", source, "ChucDanh", true, DataSourceUpdateMode.OnPropertyChanged);
            cboNgaySinh.DataBindings.Add(nameof(DateEdit.DateTime), source, "NgaySinh", true, DataSourceUpdateMode.OnPropertyChanged);
            cboGioiTinh.DataBindings.Add("Text", source, "GioiTinh", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDiaChi.DataBindings.Add("Text", source, "DiaChi", true, DataSourceUpdateMode.OnPropertyChanged);
            txtSDT.DataBindings.Add("Text", source, "SDT", true, DataSourceUpdateMode.OnPropertyChanged);
            txtCMND.DataBindings.Add("Text", source, "CMND", true, DataSourceUpdateMode.OnPropertyChanged);
            txtEmail.DataBindings.Add("Text", source, "Email", true, DataSourceUpdateMode.OnPropertyChanged);
            dgvNhanVien.DataSource = source;
        }

        private void ClearText()
        {
            txtID.Text = "";
            txtTenNhanVien.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtCMND.Text = "";
            txtEmail.Text = "";
            txtID.Focus();
        }

        private void ClearBinding()
        {
            txtID.DataBindings.Clear();
            txtTenNhanVien.DataBindings.Clear();
            cboChucDanh.DataBindings.Clear();
            cboNgaySinh.DataBindings.Clear();
            cboGioiTinh.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtCMND.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            dgvNhanVien.DataBindings.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isThem = true;
            ClearBinding();
            ClearText();
            btnHuyBo.Enabled = true;
            btnLuu.Enabled = true;
            txtID.Enabled = true;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            dgvNhanVien.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isThem)
            {
                if (NhanVienBUS.Instance.ThemNhanVien(txtID.Text, txtTenNhanVien.Text, cboChucDanh.Text, cboNgaySinh.DateTime, cboGioiTinh.Text, txtDiaChi.Text, txtSDT.Text, txtCMND.Text, txtEmail.Text))
                    MessageBox.Show("Thêm nhân viên thành công!");
                else
                    MessageBox.Show("Có lỗi xảy ra. Thêm nhân viên thất bại!");
            }
            else
            {
                if (NhanVienBUS.Instance.SuaNhanVien(txtID.Text, txtTenNhanVien.Text, cboChucDanh.Text, cboNgaySinh.DateTime, cboGioiTinh.Text, txtDiaChi.Text, txtSDT.Text, txtCMND.Text, txtEmail.Text))
                    MessageBox.Show("Chỉnh sửa nhân viên thành công!");
                else
                    MessageBox.Show("Có lỗi xảy ra. Chỉnh sửa nhân viên thất bại!");
            }
            LoadNhanVien();
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            txtID.Enabled = false;
            btnLuu.Enabled = false;
            btnHuyBo.Enabled = false;
            dgvNhanVien.Enabled = true;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa nhân viên: " + txtTenNhanVien.Text + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (NhanVienBUS.Instance.XoaNhanVien(txtID.Text))
                {
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearBinding();
                    LoadNhanVien();
                }
                else
                    MessageBox.Show("Xóa nhân viên thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            BindingNhanVien();
            btnLuu.Enabled = false;
            btnHuyBo.Enabled = false;
            txtID.Enabled = false;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            dgvNhanVien.Enabled = true;
        }

        private void txt_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            ClearBinding();
            btnHuyBo.Enabled = true;
            btnLuu.Enabled = true;
        }
    }
}
