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
    public partial class LoaiPhongGUI : DevExpress.XtraEditors.XtraUserControl
    {
        bool isThem = false;
        public LoaiPhongGUI()
        {
            InitializeComponent();
        }

        private void LoaiPhongGUI_Load(object sender, EventArgs e)
        {
            LoadLoaiPhong();
        }
        void LoadLoaiPhong()
        {
            dgvLoaiPhong.DataSource = LoaiPhongBUS.Instance.DSLoaiPhong();
            BindingLoaiPhong();
            isThem = false;
            txtID.Enabled = false;
            btnHuyBo.Enabled = false;
            btnLuu.Enabled = false;

        }

        public void BindingLoaiPhong()
        {
            BindingSource source = new BindingSource();
            source.DataSource = LoaiPhongBUS.Instance.DSLoaiPhong();
            source.DataSource = dgvLoaiPhong.DataSource;
            txtID.DataBindings.Add("Text", source, "ID", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenLoaiPhong.DataBindings.Add("Text", source, "Ten", true, DataSourceUpdateMode.OnPropertyChanged);
            txtSoGiuong.DataBindings.Add("Text", source, "SoGiuong", true, DataSourceUpdateMode.OnPropertyChanged);
            txtGia.DataBindings.Add("Text", source, "Gia", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTienPhuThu.DataBindings.Add("Text", source, "TienPhuThu", true, DataSourceUpdateMode.OnPropertyChanged);
            dgvLoaiPhong.DataSource = source;
        }

        private void ClearText()
        {
            txtID.Text = "";
            txtTenLoaiPhong.Text = "";
            txtSoGiuong.Text = "";
            txtGia.Text = "";
            txtTienPhuThu.Text = "";
            txtTenLoaiPhong.Focus();
        }

        private void ClearBinding()
        {
            txtID.DataBindings.Clear();
            txtTenLoaiPhong.DataBindings.Clear();
            txtSoGiuong.DataBindings.Clear();
            txtGia.DataBindings.Clear();
            txtTienPhuThu.DataBindings.Clear();
            dgvLoaiPhong.DataBindings.Clear();
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
            dgvLoaiPhong.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isThem)
            {
                if (LoaiPhongBUS.Instance.ThemLoaiPhong(txtTenLoaiPhong.Text, txtSoGiuong.Text, txtGia.Text, txtTienPhuThu.Text))
                    MessageBox.Show("Thêm loại phòng thành công!");
                else
                    MessageBox.Show("Có lỗi xảy ra. Thêm loại phòng thất bại!");
            }
            else
            {
                if (LoaiPhongBUS.Instance.SuaLoaiPhong(txtID.Text, txtTenLoaiPhong.Text, txtSoGiuong.Text, txtGia.Text, txtTienPhuThu.Text))
                    MessageBox.Show("Chỉnh sửa loại phòng thành công!");
                else
                    MessageBox.Show("Có lỗi xảy ra. Chỉnh sửa loại phòng thất bại!");
            }
            LoadLoaiPhong();
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnHuyBo.Enabled = false;
            dgvLoaiPhong.Enabled = true;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa Loại Phòng: " + txtTenLoaiPhong.Text + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (LoaiPhongBUS.Instance.XoaLoaiPhong(txtID.Text))
                {
                    MessageBox.Show("Xóa loại phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearBinding();
                    LoadLoaiPhong();
                }
                else
                    MessageBox.Show("Xóa loại phòng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            BindingLoaiPhong();
            btnLuu.Enabled = false;
            btnHuyBo.Enabled = false;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            dgvLoaiPhong.Enabled = true;
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
