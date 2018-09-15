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

namespace GUI
{
    public partial class ChucDanhGUI : DevExpress.XtraEditors.XtraUserControl
    {
        bool isThem = false;
        public ChucDanhGUI()
        {
            InitializeComponent();
        }

        private void ChucDanhGUI_Load(object sender, EventArgs e)
        {
            LoadChucDanh();
        }
        void LoadChucDanh()
        {
            dgvChucDanh.DataSource = ChucDanhBUS.Instance.DSChucDanh();
            BindingChucDanh();
            isThem = false;
            txtID.Enabled = false;
            btnHuyBo.Enabled = false;
            btnLuu.Enabled = false;

        }

        public void BindingChucDanh()
        {
            BindingSource source = new BindingSource();
            source.DataSource = ChucDanhBUS.Instance.DSChucDanh();
            source.DataSource = dgvChucDanh.DataSource;
            txtID.DataBindings.Add("Text", source, "ID", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenChucDanh.DataBindings.Add("Text", source, "Ten", true, DataSourceUpdateMode.OnPropertyChanged);
            dgvChucDanh.DataSource = source;
        }

        private void ClearText()
        {
            txtID.Text = "";
            txtTenChucDanh.Text = "";
            txtTenChucDanh.Focus();
        }

        private void ClearBinding()
        {
            txtID.DataBindings.Clear();
            txtTenChucDanh.DataBindings.Clear();
            dgvChucDanh.DataBindings.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isThem = true;
            ClearBinding();
            ClearText();
            btnHuyBo.Enabled = true;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            dgvChucDanh.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isThem)
            {
                if (ChucDanhBUS.Instance.ThemChucDanh(txtTenChucDanh.Text))
                    MessageBox.Show("Thêm chức danh thành công!");
                else
                    MessageBox.Show("Có lỗi xảy ra. Thêm chức danh thất bại!");
            }
            else
            {
                if (ChucDanhBUS.Instance.SuaChucDanh(txtID.Text, txtTenChucDanh.Text))
                    MessageBox.Show("Chỉnh sửa chức danh thành công!");
                else
                    MessageBox.Show("Có lỗi xảy ra. Chỉnh sửa chức danh thất bại!");
            }
            LoadChucDanh();
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnHuyBo.Enabled = false;
            dgvChucDanh.Enabled = true;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa chức danh: " + txtTenChucDanh.Text + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (ChucDanhBUS.Instance.XoaChucDanh(txtID.Text))
                {
                    MessageBox.Show("Xóa chức danh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearBinding();
                    LoadChucDanh();
                }
                else
                    MessageBox.Show("Xóa chức danh thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            BindingChucDanh();
            btnLuu.Enabled = false;
            btnHuyBo.Enabled = false;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            dgvChucDanh.Enabled = true;
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
