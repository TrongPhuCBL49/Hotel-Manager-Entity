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
    public partial class DichVuGUI : DevExpress.XtraEditors.XtraUserControl
    {
        bool isThem = false;
        public DichVuGUI()
        {
            InitializeComponent();
        }

        private void DichVuGUI_Load(object sender, EventArgs e)
        {
            LoadDichVu();
        }
        void LoadDichVu()
        {
            dgvDichVu.DataSource = DichVuBUS.Instance.DSDichVu();
            BindingDichVu();
            isThem = false;
            txtID.Enabled = false;
            btnHuyBo.Enabled = false;
            btnLuu.Enabled = false;

        }

        public void BindingDichVu()
        {
            BindingSource source = new BindingSource();
            source.DataSource = DichVuBUS.Instance.DSDichVu();
            source.DataSource = dgvDichVu.DataSource;
            txtID.DataBindings.Add("Text", source, "ID", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenDichVu.DataBindings.Add("Text", source, "Ten", true, DataSourceUpdateMode.OnPropertyChanged);
            txtGia.DataBindings.Add("Text", source, "Gia", true, DataSourceUpdateMode.OnPropertyChanged);
            dgvDichVu.DataSource = source;
        }

        private void ClearText()
        {
            txtID.Text = "";
            txtTenDichVu.Text = "";
            txtGia.Text = "";
            txtTenDichVu.Focus();
        }

        private void ClearBinding()
        {
            txtID.DataBindings.Clear();
            txtTenDichVu.DataBindings.Clear();
            txtGia.DataBindings.Clear();
            dgvDichVu.DataBindings.Clear();
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
            dgvDichVu.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isThem)
            {
                if (DichVuBUS.Instance.ThemDichVu(txtTenDichVu.Text, txtGia.Text))
                    MessageBox.Show("Thêm dịch vụ thành công!");
                else
                    MessageBox.Show("Có lỗi xảy ra. Thêm dịch vụ thất bại!");
            }
            else
            {
                if (DichVuBUS.Instance.SuaDichVu(txtID.Text, txtTenDichVu.Text, txtGia.Text))
                    MessageBox.Show("Chỉnh sửa dịch vụ thành công!");
                else
                    MessageBox.Show("Có lỗi xảy ra. Chỉnh sửa dịch vụ thất bại!");
            }
            LoadDichVu();
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnHuyBo.Enabled = false;
            dgvDichVu.Enabled = true;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dịch vụ: " + txtTenDichVu.Text + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (DichVuBUS.Instance.XoaDichVu(txtID.Text))
                {
                    MessageBox.Show("Xóa dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearBinding();
                    LoadDichVu();
                }
                else
                    MessageBox.Show("Xóa dịch vụ thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            BindingDichVu();
            btnLuu.Enabled = false;
            btnHuyBo.Enabled = false;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            dgvDichVu.Enabled = true;
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
