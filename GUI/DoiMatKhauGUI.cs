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
    public partial class DoiMatKhauGUI : DevExpress.XtraEditors.XtraUserControl
    {
        private string IdNhanVien = DangNhapGUI.IdNhanVien;
        public DoiMatKhauGUI()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (DoiMatKhauBUS.Instance.KiemTraPass(IdNhanVien, txtPassCu.Text))
                if (txtPassMoi.Text == txtXacNhanPass.Text)
                {
                    if (DoiMatKhauBUS.Instance.DoiMatKhau(IdNhanVien, txtPassMoi.Text))
                        MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Lỗi!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Xác nhận mật khẩu mới sai!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Nhập mật khẩu sai!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
