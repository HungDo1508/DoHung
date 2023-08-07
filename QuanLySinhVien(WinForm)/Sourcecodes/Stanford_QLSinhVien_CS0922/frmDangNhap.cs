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
    public partial class frmDangNhap : Form
    {
        /// <summary>
        /// Lưu trạng thái đăng nhập thành công
        /// </summary>
        public bool isThanhCong { get; set; }

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Xử lý đăng nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //Khai báo biến
            string tenDangNhap = "", matKhau = "";

            //Lấy thông tin trên giao diện
            tenDangNhap = txtTenDangNhap.Text.Trim();
            matKhau = txtMatKhau.Text;

            if(tenDangNhap.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập tên đăng nhập", "Thông báo");
                txtTenDangNhap.Focus();
                return;
            }

            if (matKhau.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập mật khẩu đăng nhập", "Thông báo");
                txtMatKhau.Focus();
                return;
            }

            //Khai báo đối tượng
            NguoiDungBusiness bus = new NguoiDungBusiness();
            NguoiDung objUser = bus.LayThongTinTheoTenDangNhap(tenDangNhap);

            if(objUser != null)//Nếu có người dùng
            {
                string matKhauDb = objUser.MatKhau;

                if(matKhau== matKhauDb)//True
                {
                    frmCuaSoChinh.UserId = objUser.Id;
                    frmCuaSoChinh.UserName = tenDangNhap;
                    isThanhCong = true;
                    this.Close();
                }  
                else
                {
                    MessageBox.Show("Mật khẩu nhập không chính xác", "Thông báo");
                    txtMatKhau.Focus();
                }    
            }    
            else
            {
                MessageBox.Show("Không tồn tại tài khoản trong hệ thống. Bạn vui lòng kiểm tra lại", "Thông báo");
                txtTenDangNhap.Focus();
            }    
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            isThanhCong = false;
            this.Close();
        }
    }
}
