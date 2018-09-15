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
    public partial class KhachHangGUI : DevExpress.XtraEditors.XtraUserControl
    {
        bool isThem = false;
        public KhachHangGUI()
        {
            InitializeComponent();
        }

        private void KhachHangGUI_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
            LoadGioiTinh();
        }
        void LoadKhachHang()
        {
            dgvKhachHang.DataSource = KhachHangBUS.Instance.DSKhachHang();
            BindingKhachHang();
            isThem = false;
            txtID.Enabled = false;
            btnHuyBo.Enabled = false;
            btnLuu.Enabled = false;
        }
        void LoadGioiTinh()
        {
            List<string> TrangThai = new List<string>();
            TrangThai.Add("Nam");
            TrangThai.Add("Nữ");
            TrangThai.Add("Khác");
            cboGioiTinh.Properties.Items.AddRange(TrangThai);
        }
        public void BindingKhachHang()
        {
            BindingSource source = new BindingSource();
            source.DataSource = KhachHangBUS.Instance.DSKhachHang();
            source.DataSource = dgvKhachHang.DataSource;
            txtID.DataBindings.Add("Text", source, "ID", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenKhachHang.DataBindings.Add("Text", source, "Ten", true, DataSourceUpdateMode.OnPropertyChanged);
            cboNgaySinh.DataBindings.Add(nameof(DateEdit.DateTime), source, "NgaySinh", true, DataSourceUpdateMode.OnPropertyChanged);
            cboGioiTinh.DataBindings.Add("Text", source, "GioiTinh", true, DataSourceUpdateMode.OnPropertyChanged);
            txtQuocTich.DataBindings.Add("Text", source, "QuocTich", true, DataSourceUpdateMode.OnPropertyChanged);
            txtSDT.DataBindings.Add("Text", source, "SDT", true, DataSourceUpdateMode.OnPropertyChanged);
            txtCMND.DataBindings.Add("Text", source, "CMND", true, DataSourceUpdateMode.OnPropertyChanged);
            txtEmail.DataBindings.Add("Text", source, "Email", true, DataSourceUpdateMode.OnPropertyChanged);
            dgvKhachHang.DataSource = source;
        }

        private void ClearText()
        {
            txtID.Text = "";
            txtTenKhachHang.Text = "";
            txtQuocTich.Text = "";
            txtSDT.Text = "";
            txtCMND.Text = "";
            txtEmail.Text = "";
            txtID.Focus();
        }

        private void ClearBinding()
        {
            txtID.DataBindings.Clear();
            txtTenKhachHang.DataBindings.Clear();
            cboNgaySinh.DataBindings.Clear();
            cboGioiTinh.DataBindings.Clear();
            txtQuocTich.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtCMND.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            dgvKhachHang.DataBindings.Clear();
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
            dgvKhachHang.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isThem)
            {
                if (KhachHangBUS.Instance.ThemKhachHang(txtID.Text, txtTenKhachHang.Text, cboNgaySinh.DateTime, cboGioiTinh.Text, txtQuocTich.Text, txtSDT.Text, txtCMND.Text, txtEmail.Text))
                    MessageBox.Show("Thêm khách hàng thành công!");
                else
                    MessageBox.Show("Có lỗi xảy ra. Thêm khách hàng thất bại!");
            }
            else
            {
                if (KhachHangBUS.Instance.SuaKhachHang(txtID.Text, txtTenKhachHang.Text, cboNgaySinh.DateTime, cboGioiTinh.Text, txtQuocTich.Text, txtSDT.Text, txtCMND.Text, txtEmail.Text))
                    MessageBox.Show("Chỉnh sửa khách hàng thành công!");
                else
                    MessageBox.Show("Có lỗi xảy ra. Chỉnh sửa khách hàng thất bại!");
            }
            LoadKhachHang();
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            txtID.Enabled = false;
            btnLuu.Enabled = false;
            btnHuyBo.Enabled = false;
            dgvKhachHang.Enabled = true;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa khách hàng: " + txtTenKhachHang.Text + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (KhachHangBUS.Instance.XoaKhachHang(txtID.Text))
                {
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearBinding();
                    LoadKhachHang();
                }
                else
                    MessageBox.Show("Xóa khách hàng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            BindingKhachHang();
            btnLuu.Enabled = false;
            btnHuyBo.Enabled = false;
            txtID.Enabled = false;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            dgvKhachHang.Enabled = true;
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
