using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraTab;
using BUS;
using DevExpress.XtraReports.UI;

namespace GUI
{
    public partial class MainGUI : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainGUI()
        {
            InitializeComponent();
        }

#region thiết lập TabControl
        private void tabMain_CloseButtonClick(object sender, EventArgs e)
        {
            tabMain.TabPages.RemoveAt(tabMain.SelectedTabPageIndex);
            tabMain.SelectedTabPageIndex = tabMain.TabPages.Count - 1;
        }

        private void tabMain_ControlAdded(object sender, ControlEventArgs e)
        {
            tabMain.SelectedTabPageIndex = tabMain.TabPages.Count - 1;
        }

        private void AddTabControl(UserControl userControl, string itemTabName)
        {
            bool isExits = false;
            foreach (XtraTabPage tabItem in tabMain.TabPages)
            {
                if (tabItem.Text == itemTabName)
                {
                    isExits = true;
                    tabMain.SelectedTabPage = tabItem;
                }
            }

            if (isExits == false)
            {
                AddTab addTab = new AddTab();
                addTab.AddTabControl(tabMain, itemTabName, userControl);
            }
        }
#endregion
        private void btnDoiMatKhau_ItemClick(object sender, ItemClickEventArgs e)
        {
            DoiMatKhauGUI doiMatKhauGUI = new DoiMatKhauGUI();
            AddTabControl(doiMatKhauGUI, "Đổi mật khẩu");
        }

        private void btnLoaiPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoaiPhongGUI loaiPhongGUI = new LoaiPhongGUI();
            AddTabControl(loaiPhongGUI, "Loại phòng");
        }

        private void btnChucDanh_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChucDanhGUI chucDanhGUI = new ChucDanhGUI();
            AddTabControl(chucDanhGUI, "Chức danh");
        }

        private void btnDichVu_ItemClick(object sender, ItemClickEventArgs e)
        {
            DichVuGUI dichVuGUI = new DichVuGUI();
            AddTabControl(dichVuGUI, "Dịch vụ");
        }

        private void btnPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            PhongGUI phongGUI = new PhongGUI();
            AddTabControl(phongGUI, "Phòng");
        }

        private void btnNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            NhanVienGUI nhanVienGUI = new NhanVienGUI();
            AddTabControl(nhanVienGUI, "Nhân viên");
        }

        private void btnKhachHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            KhachHangGUI khachHangGUI = new KhachHangGUI();
            AddTabControl(khachHangGUI, "Khách hàng");
        }

        private void btnDSNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void btnDSPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            DSPhongGUI dSPhongGUI = new DSPhongGUI();
            AddTabControl(dSPhongGUI, "DS phòng");
        }

        private void btnDatPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            DatPhongGUI datPhongGUI = new DatPhongGUI();
            AddTabControl(datPhongGUI, "Đặt phòng");
        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}