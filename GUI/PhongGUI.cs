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
    public partial class PhongGUI : DevExpress.XtraEditors.XtraUserControl
    {
        bool isThem = false;
        public PhongGUI()
        {
            InitializeComponent();
        }

        private void PhongGUI_Load(object sender, EventArgs e)
        {
            LoadPhong();
        }
        void LoadPhong()
        {
            dgvPhong.DataSource = PhongBUS.Instance.DSPhong();
            LoadLoaiPhong();
            LoadTrangThai();
            BindingPhong();
            isThem = false;
            txtID.Enabled = false;
            btnHuyBo.Enabled = false;
            btnLuu.Enabled = false;
            cboTrangThai.Enabled = false;

        }
        void LoadLoaiPhong()
        {
            DataTable dtbLoaiPhong = LoaiPhongBUS.Instance.DSLoaiPhong();
            foreach (DataRow row in dtbLoaiPhong.Rows)
                cboLoaiPhong.Properties.Items.Add(row["Ten"]);
        }
        void LoadTrangThai()
        {
            List<string> TrangThai = new List<string>();
            TrangThai.Add("Đã đặt");
            TrangThai.Add("Đã nhận khách");
            TrangThai.Add("Chưa đặt");
            cboTrangThai.Properties.Items.AddRange(TrangThai);
        }
        public void BindingPhong()
        {
            BindingSource source = new BindingSource();
            source.DataSource = PhongBUS.Instance.DSPhong();
            source.DataSource = dgvPhong.DataSource;
            txtID.DataBindings.Add("Text", source, "ID", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenPhong.DataBindings.Add("Text", source, "Ten", true, DataSourceUpdateMode.OnPropertyChanged);
            cboLoaiPhong.DataBindings.Add("Text", source, "LoaiPhong", true, DataSourceUpdateMode.OnPropertyChanged);
            cboTrangThai.DataBindings.Add("Text", source, "TrangThai", true, DataSourceUpdateMode.OnPropertyChanged);
            dgvPhong.DataSource = source;
        }

        private void ClearText()
        {
            txtID.Text = "";
            txtTenPhong.Text = "";
            txtID.Focus();
        }

        private void ClearBinding()
        {
            txtID.DataBindings.Clear();
            txtTenPhong.DataBindings.Clear();
            cboLoaiPhong.DataBindings.Clear();
            cboTrangThai.DataBindings.Clear();
            dgvPhong.DataBindings.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isThem = true;
            ClearBinding();
            ClearText();
            btnHuyBo.Enabled = true;
            btnLuu.Enabled = true;
            txtID.Enabled = true;
            cboTrangThai.SelectedIndex = 2;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            dgvPhong.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isThem)
            {
                if (PhongBUS.Instance.ThemPhong(txtID.Text, txtTenPhong.Text, cboLoaiPhong.Text, cboTrangThai.Text))
                    MessageBox.Show("Thêm phòng thành công!");
                else
                    MessageBox.Show("Có lỗi xảy ra. Thêm phòng thất bại!");
            }
            else
            {
                if (PhongBUS.Instance.SuaPhong(txtID.Text, txtTenPhong.Text, cboLoaiPhong.Text, cboTrangThai.Text))
                    MessageBox.Show("Chỉnh sửa phòng thành công!");
                else
                    MessageBox.Show("Có lỗi xảy ra. Chỉnh sửa phòng thất bại!");
            }
            LoadPhong();
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            txtID.Enabled = false;
            btnLuu.Enabled = false;
            btnHuyBo.Enabled = false;
            dgvPhong.Enabled = true;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa phòng: " + txtTenPhong.Text + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (PhongBUS.Instance.XoaPhong(txtID.Text))
                {
                    MessageBox.Show("Xóa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearBinding();
                    LoadPhong();
                }
                else
                    MessageBox.Show("Xóa phòng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            BindingPhong();
            btnLuu.Enabled = false;
            btnHuyBo.Enabled = false;
            txtID.Enabled = false;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            dgvPhong.Enabled = true;
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
