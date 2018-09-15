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
using DevExpress.XtraLayout;
using BUS;
using DTO;

namespace GUI
{
    public partial class DSPhongGUI : DevExpress.XtraEditors.XtraUserControl
    {
        public DSPhongGUI()
        {
            InitializeComponent();
        }

        public void LoadDSPhong()
        {
            List<PhongDTO> dsPhong = DSPhongBUS.Instance.DSPhong();
            foreach (PhongDTO phong in dsPhong)
            {
                SimpleButton btn = new SimpleButton() { Width = 100, Height = 100 };
                btn.Name = "btn" + phong.Ten;
                btn.Text = phong.Ten;
                if (phong.IdTrangThai == 3)
                    btn.ImageOptions.Image = Image.FromFile("../../Resources/house (2).png");
                else
                    btn.ImageOptions.Image = Image.FromFile("../../Resources/home.png");
                btn.ImageOptions.Location = ImageLocation.TopCenter;
                fllDSPhong.Controls.Add(btn);
            }
        }

        private void DSPhongGUI_Load(object sender, EventArgs e)
        {
            LoadDSPhong();
        }
    }
}
