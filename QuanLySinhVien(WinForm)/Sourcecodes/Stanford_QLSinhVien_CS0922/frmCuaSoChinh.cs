using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stanford_QLSinhVien_CS0922
{
    public partial class frmCuaSoChinh : Form
    {
        public  static int UserId { get; set; }

        /// <summary>
        /// Lưu thông tin tên đăng nhập
        /// </summary>
        public static string UserName { get; set; }

        public frmCuaSoChinh()
        {
            InitializeComponent();
        }

        private void menuItemSinhVien_Click(object sender, EventArgs e)
        {
            //Khai báo 1 đối tượng
            frmDanhSachSinhVien frmSV = new frmDanhSachSinhVien();
            //Thiết lập form này là con của form cửa sổ chính
            frmSV.MdiParent = this;
            //Hiển thị
            frmSV.Show();
        }

        private void frmCuaSoChinh_Load(object sender, EventArgs e)
        {
            DangNhapHeThong();
        }

        private void menuItemDangXuat_Click(object sender, EventArgs e)
        {
            DangNhapHeThong();
        }

        private void menuItemDangNhap_Click(object sender, EventArgs e)
        {
            DangNhapHeThong();
        }

        private void menuItemDong_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Gọi form đăng nhập và kiểm tra quyền
        /// </summary>
        private void DangNhapHeThong()
        {
            UserId = 0;
            UserName = "";
            KiemTraQuyenSuDung(false);

            frmDangNhap frmLogin = new frmDangNhap();

            frmLogin.ShowDialog();

            KiemTraQuyenSuDung(frmLogin.isThanhCong);
        }

        /// <summary>
        /// Hàm kiểm tra quyền sử dụng
        /// </summary>
        /// <param name="isQuyen"></param>
        private void KiemTraQuyenSuDung(bool isQuyen)
        {
            menuItemDangNhap.Visible = !isQuyen;
            menuItemDangXuat.Visible = isQuyen;
            menuItemNguoiDung.Visible = isQuyen;
            menuNghiepVu.Enabled = isQuyen;
            menuDanhMuc.Enabled = isQuyen;
            menuBaoCao.Enabled = isQuyen;

            if(isQuyen)
            {
                lblTenDangNhap.Text = UserName;
            }    
            else
            {
                lblTenDangNhap.Text = "Chưa đăng nhập";
            }    
        }
    }
}
